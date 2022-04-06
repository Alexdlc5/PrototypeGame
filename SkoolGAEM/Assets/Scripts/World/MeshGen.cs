using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    //add health kits
    //random extra loot (weapons armor new weapon types)
    //line up terrain and not hitboxes
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
    public GameObject itemPlacer;
    public GameObject building;
    public GameObject rock;
    public GameObject rocka;
    public Color currentcolor;
    public Transform folder;
    public GameObject origin;
    public GameObject spawner;
    public Transform spawnerfolder;

    public float currentcoordsx = 0;
    public float currentcoordsz = 0;

    void Start()
    {
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
        
        //changes the current mesh color to random value
        currentcolor = new Color(Random.Range(1f, 1f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
        //sets mesh and mesh color
        GetComponent<MeshCollider>().sharedMesh = mesh;
        //values that will hold hue, saturation and brightness value of current color
        float H, S, V;
        Color.RGBToHSV(currentcolor, out H, out S, out V);
        //decreases saturation and brightness
        S -= .05f;
        V -= .05f;
        //set current color with new lower saturation
        currentcolor = Color.HSVToRGB(H,S,V);
        GetComponent<MeshRenderer>().material.color = currentcolor;

        //places assets on map
        GameObject ip = Instantiate(itemPlacer, transform);
        ip.SendMessage("setXoff", currentcoordsx);
        ip.SendMessage("setZoff", currentcoordsz);
        ip.SendMessage("setObject", rock);
        ip.SendMessage("setObjectColor", currentcolor);
        ip.SendMessage("setYoff", .6);
        ip.SendMessage("setFolder", folder);
        ip.SendMessage("PlaceObjects", 20);

        ip.SendMessage("setObject", rocka);
        ip.SendMessage("setObjectColor", currentcolor);
        ip.SendMessage("setYoff", .6);
        ip.SendMessage("setFolder", folder);
        ip.SendMessage("PlaceObjects", 20);

        ip.SendMessage("isSpawner" , true);
        ip.SendMessage("setYoff", 10);
        ip.SendMessage("setObject", spawner);
        ip.SendMessage("setFolder", spawnerfolder);
        ip.SendMessage("PlaceObjects", 3);

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
                        setVerts(index, x, z, 1.75f);
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
