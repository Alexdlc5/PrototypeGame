using System.Collections;
using System.Collections.Generic;
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
    public GameObject grass;
    public GameObject cactus;
    public GameObject healthpickup;
    public Color currentcolor;
    //misc
    public Transform folder;
    public GameObject origin;
    //spanwers
    public GameObject spawner;
    public GameObject spawnera;
    public GameObject spawnerb;
    public GameObject spawnerc;
    public Transform spawnerfolder;
    //buildings
    public int chanceofbuilding = 100;
    public int buildingtype;
    public GameObject building_a;
    public GameObject building_b;
    public GameObject building_c;
    public GameObject building_d;
    public GameObject building_e;

    private string biome = "";

    public float currentcoordsx = 0;
    public float currentcoordsz = 0;

    void Start()
    {
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

        //places assets on map
        GameObject ip = Instantiate(itemPlacer, transform);
        ip.SendMessage("setXoff", currentcoordsx);
        ip.SendMessage("setZoff", currentcoordsz);
        
        //checks biome, spawns accordingly
        if (biome.Equals("Pine"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(Random.Range(.5f, .8f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .05f;
            V -= .05f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);
            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            ip.SendMessage("isSpawner", false);
            // 1 / [chanceofbuilding] chance of spwaning building
            if (Random.Range(1, chanceofbuilding) <= chanceofbuilding / 4)
            {
                //sets building
                buildingtype = Random.Range(0, 4);
                if (buildingtype < 1)
                {
                    ip.SendMessage("setObject", building_e);
                }
                else if (buildingtype < 2)
                {
                    ip.SendMessage("setObject", building_a);
                }
                else if (buildingtype < 3)
                {
                    ip.SendMessage("setObject", building_b);
                }
                else if (buildingtype < 4)
                {
                    ip.SendMessage("setObject", building_c);
                }
                else
                {
                    ip.SendMessage("setObject", building_d);
                }
                //finishes placement settings then places building
                ip.SendMessage("setScaleRange", new Vector2(5, 5));
                ip.SendMessage("setRandomRotation", true);
                ip.SendMessage("setYoff", -.5f);
                ip.SendMessage("PlaceObjects", 1);
            }

            ip.SendMessage("setObject", tree);
            ip.SendMessage("setScaleRange", new Vector2(3,5));
            ip.SendMessage("setRandomRotation", true);
            ip.SendMessage("setYoff", -10);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 15); 

            ip.SendMessage("setObject", rock);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", .6);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 10);

            ip.SendMessage("setObject", healthpickup);
            ip.SendMessage("setYoff", 3);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", rocka);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", .6);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 10);

            ip.SendMessage("isSpawner", true);
            ip.SendMessage("setYoff", 10);
            ip.SendMessage("setObject", spawnerb);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", spawnera);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", spawner);
            ip.SendMessage("PlaceObjects", 1);
        }
        else if (biome.Equals("Grass_Planes"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(Random.Range(.5f, .8f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .05f;
            V -= .05f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);
            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            ip.SendMessage("isSpawner", false);
            // 1 / [chanceofbuilding] chance of spwaning building
            if (Random.Range(1, chanceofbuilding) <= chanceofbuilding / 4)
            {
                //sets building
                buildingtype = Random.Range(0, 4);
                if (buildingtype < 1)
                {
                    ip.SendMessage("setObject", building_e);
                }
                else if (buildingtype < 2)
                {
                    ip.SendMessage("setObject", building_a);
                }
                else if (buildingtype < 3)
                {
                    ip.SendMessage("setObject", building_b);
                }
                else if (buildingtype < 4)
                {
                    ip.SendMessage("setObject", building_c);
                }
                else
                {
                    ip.SendMessage("setObject", building_d);
                }
                //finishes placement settings then places building
                ip.SendMessage("setScaleRange", new Vector2(5, 5));
                ip.SendMessage("setRandomRotation", true);
                ip.SendMessage("setYoff", -.5f);
                ip.SendMessage("PlaceObjects", 1);
            }

            ip.SendMessage("setObject", rock);
            ip.SendMessage("setScaleRange", new Vector2(2, 3f));
            ip.SendMessage("setRandomRotation", true);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", .2);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 10);

            ip.SendMessage("setObject", healthpickup);
            ip.SendMessage("setYoff", .6);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", rocka);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", .2);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 10);

            ip.SendMessage("setObject", oak_tree);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", -5);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 5);

            ip.SendMessage("isSpawner", true);
            ip.SendMessage("setYoff", 10);
            ip.SendMessage("setObject", spawner);
            ip.SendMessage("setFolder", spawnerfolder);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", spawnerc);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("setObject", spawnera);
            ip.SendMessage("PlaceObjects", 1);
        }
        else if (biome.Equals("Desert"))
        {
            //changes the current mesh color to random value
            currentcolor = new Color(1, Random.Range(0.6f, .8f), 0, 1.0f);
            //sets mesh and mesh color
            GetComponent<MeshCollider>().sharedMesh = mesh;
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .05f;
            V -= .05f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);
            GetComponent<MeshRenderer>().material.color = currentcolor;

            origin.GetComponent<WorldOrigin>().currentbiomecount++;

            ip.SendMessage("isSpawner", false);
            // 1 / [chanceofbuilding] chance of spwaning building
            if (Random.Range(1, chanceofbuilding) <= chanceofbuilding / 4)
            {
                //sets building
                buildingtype = Random.Range(0, 4);
                if (buildingtype < 1)
                {
                    ip.SendMessage("setObject", building_e);
                }
                else if (buildingtype < 2)
                {
                    ip.SendMessage("setObject", building_a);
                }
                else if (buildingtype < 3)
                {
                    ip.SendMessage("setObject", building_b);
                }
                else if (buildingtype < 4)
                {
                    ip.SendMessage("setObject", building_c);
                }
                else
                {
                    ip.SendMessage("setObject", building_d);
                }
                //finishes placement settings then places building
                ip.SendMessage("setScaleRange", new Vector2(5, 5));
                ip.SendMessage("setRandomRotation", true);
                ip.SendMessage("setYoff", -1);
                ip.SendMessage("PlaceObjects", 1);
            }

            ip.SendMessage("setObject", cactus);
            ip.SendMessage("setScaleRange", new Vector2(2, 3));
            ip.SendMessage("setRandomRotation", true);
            ip.SendMessage("setYoff", -8);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 9);


            ip.SendMessage("setObject", rocka);
            ip.SendMessage("setScaleRange", new Vector2(1, 5));
            ip.SendMessage("setRandomRotation", true);
            ip.SendMessage("setObjectColor", currentcolor);
            ip.SendMessage("setYoff", -.2);
            ip.SendMessage("setFolder", folder);
            ip.SendMessage("PlaceObjects", 10);

            ip.SendMessage("setObject", healthpickup);
            ip.SendMessage("setYoff", .6);
            ip.SendMessage("PlaceObjects", 1);

            ip.SendMessage("isSpawner", true);
            ip.SendMessage("setYoff", 10);
            ip.SendMessage("setObject", spawnera);
            ip.SendMessage("setFolder", spawnerfolder);
            ip.SendMessage("PlaceObjects", -.5f);

            ip.SendMessage("setObject", spawnerc);
            ip.SendMessage("PlaceObjects", 2);
        }


            //visual perlin
            //Renderer renderer = GetComponent<Renderer>();
            //renderer.material.mainTexture = GenTexture();
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
