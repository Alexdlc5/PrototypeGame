using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTest : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20;
    public float offsetx = 100f;
    public float offsety = 100f;
    public float testx = 1;
    public float testy = 1;
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenTexture();
    }

    Texture2D GenTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x * testx, y * testy);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return(texture);
    }

    Color CalcColor(float x, float y)
    {
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / height * scale + offsety;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
