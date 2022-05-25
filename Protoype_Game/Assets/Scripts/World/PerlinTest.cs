using UnityEngine;

public class PerlinTest : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20;
    public float offsetx = 100f;
    public float offsety = 100f;
    void Update()
    {
        //creates new render object and sets the texture
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenTexture();
    }

    Texture2D GenTexture()
    {
        //adds texture and color then applies it
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
        return(texture);
    }

    Color CalcColor(float x, float y)
    {
        //returns color based on world coords
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / height * scale + offsety;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
