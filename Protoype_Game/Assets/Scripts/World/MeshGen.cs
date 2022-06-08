using UnityEngine;

public class MeshGen : MonoBehaviour
{
    //random extra loot (weapons armor new weapon types)
    //mesh building
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] UVs;
    public int width = 256;
    public int height = 256;
    public float offsetx = 100;
    public float offsetz = 100;
    public float scale = 20;
    public int xSize = 20;
    public int zSize = 20;
    public float amp = 1;
    public Texture texture;
    //props
    public GameObject itemPlacer;
    public GameObject building;
    public GameObject rock;
    public GameObject rocka;
    public GameObject tree;
    public GameObject oak_tree;
    public GameObject talltree;
    public GameObject grass;
    public GameObject cactus;
    public GameObject healthpickup;
    public Color currentcolor;
    //misc
    public Transform folder;
    public GameObject origin;
    public int goahead = -1;
    public bool queuerequested = false;

    //spanwers
    public GameObject simpleBoss;
    public GameObject spawner;
    public GameObject spawnera;
    public GameObject spawnerb;
    public GameObject spawnerc;
    public Transform spawnerfolder;

    private string biome = "";

    public float currentcoordsx = 0;
    public float currentcoordsz = 0;

    void Start()
    {
        origin = GameObject.FindGameObjectWithTag("WorldOrigin");
        //sets biome to start 
        biome = origin.GetComponent<WorldOrigin>().currentbiome;

        //off set the noise for the origins noise
        offsetx = origin.GetComponent<WorldOrigin>().offsetx + currentcoordsx / 200;
        offsetz = origin.GetComponent<WorldOrigin>().offsetz + currentcoordsz / 200;

        //sets up mesh and mesh filter
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //random amplitude given by origin
        amp = origin.GetComponent<WorldOrigin>().amp;

        //generates mesh
        CreateShape();
        //updates it
        UpdateMesh();

        //add biomes, snowy, plamtree, open field with flowers
        goahead = origin.GetComponent<WorldOrigin>().requestQueue();
        queuerequested = true;
        //visual perlin
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = GenTexture();
    }
    private void Update()
    {
        if (queuerequested && origin.GetComponent<WorldOrigin>().itemplacerqueue.Peek() == goahead)
        {
            generateProps(biome);
            Destroy(gameObject.GetComponent<MeshGen>());
        }
    }
    void CreateShape()
    {

        //creates grid of vertices
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        
        int index = 0;
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                if (z <= 2 || zSize - 2 <= z || x <= 2 || xSize - 2 <= x)
                {
                    if (z <= 1 || zSize - 1 <= z || x <= 1 || xSize - 1 <= x)
                    {
                        //pixel to world coord and set vertices
                        setVerts(index, x, z, 20f);
                        index++;
                    }
                    else
                    {
                        //pixel to world coord and set vertices
                        setVerts(index, x, z, 1.1f);
                        index++;
                    }
                }
                else
                {
                    //pixel to world coord and set vertices
                    setVerts(index, x, z, 1);
                    index++;
                }
            }
        }
        
        //creates triangles/squares in grid
        //             O       O
        //            /\------/
        //           /  \    /
        //          /    \  /
        //         /------\/    
        //        O        O
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tri = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //first triangle
                triangles[tri] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                //second triangle
                triangles[tri + 3] = triangles[tri + 2];
                triangles[tri + 4] = triangles[tri + 1];
                triangles[tri + 5] = vert + xSize + 2;

                vert++;
                tri += 6;
            }
            vert++;
        }

        UVs = new Vector2[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                UVs[i] = new Vector2((float)x / xSize,(float)z / zSize);
                i++;
            }
        }
    } 
    void generateProps(string currentbiome)
    {
        //places assets on map
        GameObject ip = Instantiate(itemPlacer, transform);
        ItemPlacer itemplacer = ip.GetComponent<ItemPlacer>();
        itemplacer.setXoff(currentcoordsx);
        itemplacer.setZoff(currentcoordsz);

        //checks biome, spawns accordingly
        if (currentbiome.Equals("Pine"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(Random.Range(.5f, .8f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .01f;
            V -= .01f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);

            if (origin.GetComponent<WorldOrigin>().isHell)
            {
                currentcolor = new Color(currentcolor.r + 100, currentcolor.g, currentcolor.b, currentcolor.a);
            }

            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            //Item placer methods described in Item Placer script
            itemplacer.setObject(tree);
            itemplacer.setScaleRange(new Vector2(3, 5));
            itemplacer.setRandomRotation(true);
            itemplacer.setYoff(-10);
            itemplacer.setFolder(folder);
            itemplacer.PlaceObjects(10);

            itemplacer.setObject(rock);
            itemplacer.setObjectColor(currentcolor);
            itemplacer.setYoff(.6f);
            itemplacer.PlaceObjects(8);

            itemplacer.setObject(healthpickup);
            itemplacer.setYoff(3);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(rocka);
            itemplacer.setYoff(.6f);
            itemplacer.PlaceObjects(5);

            itemplacer.setYoff(10);
            itemplacer.setObject(spawnerb);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(spawnera);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(spawner);
            itemplacer.PlaceObjects(1);
        }
        else if (currentbiome.Equals("Oak"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(Random.Range(.5f, .8f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .01f;
            V -= .01f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);

            if (origin.GetComponent<WorldOrigin>().isHell)
            {
                currentcolor = new Color(currentcolor.r + 100, currentcolor.g, currentcolor.b, currentcolor.a);
            }

            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            itemplacer.setObject(rock);
            itemplacer.setScaleRange(new Vector2(2, 3f));
            itemplacer.setObjectColor(currentcolor);
            itemplacer.setYoff(.2f);
            itemplacer.setFolder(folder);
            itemplacer.PlaceObjects(10);

            itemplacer.setObject(healthpickup);
            itemplacer.setYoff(.6f);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(rocka);
            itemplacer.setYoff(.2f);
            itemplacer.PlaceObjects(10);

            itemplacer.setObject(oak_tree);
            itemplacer.setScaleRange(new Vector2(1, 2f));
            itemplacer.setYoff(-5);
            itemplacer.PlaceObjects(3);

            itemplacer.setObject(talltree);
            itemplacer.setObjectColor(currentcolor);
            itemplacer.setYoff(-5);
            itemplacer.PlaceObjects(4);
            itemplacer.setScaleRange(new Vector2(2, 3f));

            itemplacer.setYoff(10);
            itemplacer.setObject(spawner);
            itemplacer.setFolder(spawnerfolder);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(spawnerc);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(spawnera);
            itemplacer.PlaceObjects(1);
        }
        else if (currentbiome.Equals("Desert"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(1, Random.Range(0.6f, .8f), 0, 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .01f;
            V -= .01f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);

            if (origin.GetComponent<WorldOrigin>().isHell)
            {
                currentcolor = new Color(currentcolor.r + 100, currentcolor.g, currentcolor.b, currentcolor.a);
            }

            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            itemplacer.setObject(cactus);
            itemplacer.setScaleRange(new Vector2(2, 3));
            itemplacer.setYoff(-8);
            itemplacer.setFolder(folder);
            itemplacer.PlaceObjects(6);


            itemplacer.setObject(rocka);
            itemplacer.setScaleRange(new Vector2(1, 5));
            itemplacer.setObjectColor(currentcolor);
            itemplacer.setYoff(-.2f);
            itemplacer.PlaceObjects(10);

            itemplacer.setObject(healthpickup);
            itemplacer.setYoff(.6f);
            itemplacer.PlaceObjects(1);

            itemplacer.setYoff(10);
            itemplacer.setObject(spawnera);
            itemplacer.setFolder(spawnerfolder);
            itemplacer.PlaceObjects(1);

            itemplacer.setObject(spawnerc);
            itemplacer.PlaceObjects(2);
        }
        Destroy(ip);
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = UVs;

        mesh.RecalculateNormals();
        //if size increase wanted add multipier here
        transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
    }

    Texture2D GenTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return (texture);
    }

    Color CalcColor(float x, float y)
    {
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / height * scale + offsetz;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public void setOrigin(GameObject origin)
    {
        this.origin = origin;
    }

    void setVerts(int index, float x, float z, float offset)
    {
        //pixel to world coord
        float xCoord = (float)x / width * scale + offsetx;
        float zCoord = (float)z / height * scale + offsetz;
        float y = Mathf.PerlinNoise(xCoord, zCoord) / offset;
        vertices[index] = new Vector3(x, y * amp, z);
    }
}
