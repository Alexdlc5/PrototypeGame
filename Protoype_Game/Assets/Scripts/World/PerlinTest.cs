using UnityEngine;

public class PerlinTest : MonoBehaviour
{
    //size
    public int width = 256;
    public int height = 256;
    public float scale = 20;
    //offset
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
        //goes thru pixels setting color
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

    //uses perlin noise to set pixel color
    Color CalcColor(float x, float y)
    {
        //returns color based on world coords
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / height * scale + offsety;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
