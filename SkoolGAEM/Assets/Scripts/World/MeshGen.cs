using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] UVs;
    
    public int width = 256;
    public int height = 256;
    public int offsetx = 100;
    public int offsetz = 100;
    public float scale = 20;
    public float scaleMultiplier = 1;
    public int xSize = 20;
    public int zSize = 20;
    public float amp = 1;
    public Texture texture;
    public GameObject itemPlacer;
    public GameObject building;

    void Start()
    {
        //random offset in noise
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);
        
        //sets up mesh and mesh filter
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
       
        amp = Random.Range(15, 35);
        //generates mesh
        CreateShape();
        //updates it
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh;
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.1f, .2f), Random.Range(0.1f, 1f), Random.Range(0.0f, 0.01f), 1.0f);
        GetComponent<MeshRenderer>().material.SetTexture("GridPattern", texture);

        GameObject ip = Instantiate(itemPlacer);
        ip.SendMessage("setObject", building);
        ip.SendMessage("PlaceObjects");
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
                //pixel to world coord
                float xCoord = (float)x / width * scale + offsetx;
                float zCoord = (float)z / height * scale + offsetz;
                float y = Mathf.PerlinNoise(xCoord, zCoord);
                vertices[index] = new Vector3(x, y * amp, z);
                index++;
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
        transform.localScale = new Vector3(transform.localScale.x * scaleMultiplier, 1, transform.localScale.z * scaleMultiplier);
    }
}