using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    //Map is 900x900 units with current settings
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] UVs;
    
    public int width = 256;
    public int height = 256;
    public int offsetx = 100;
    public int offsetz = 100;
    public float colordamp = 1;
    public float stretchx = 1;
    public float stretchy = 1;
    public float scale = 20;
    public float scaleMultiplier = 1;
    public int xSize = 20;
    public int zSize = 20;
    public GameObject vertmark;
    public float amp = 1;

    void Start()
    {
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh;
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
