using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    
    public int width = 256;
    public int height = 256;
    public float offsetx = 100f;
    public float offsety = 100f;
    public float colordamp = 1;
    public float stretchx = 1;
    public float stretchy = 1;
    public float scale = 20;
    public int xSize = 20;
    public int zSize = 20;
    public float amp = 1;

    void Start()
    {
        offsetx = Random.Range(0, 9999f);
        offsety = Random.Range(0, 9999f);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
       
        Renderer renderer = GetComponent<Renderer>();

        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        
        int index = 0;
        for (int i = 0; i <= zSize; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                float xCoord = (float)j / width * scale + offsetx;
                float yCoord = (float)i / height * scale + offsety;
                float y = Mathf.PerlinNoise(xCoord, yCoord);
                vertices[index] = new Vector3(j, y * amp, i);
                index++;
            }
        }
        
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tri = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tri] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                triangles[tri + 3] = vert + 1;
                triangles[tri + 4] = vert + xSize + 1;
                triangles[tri + 5] = vert + xSize + 2;

                vert++;
                tri += 6;
            }
            vert++;
        }
    } 

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
