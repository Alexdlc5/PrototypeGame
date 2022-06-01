using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    public Slider speedSlider;
    public Image bar;
    
    private float maxspeed = 0;
    private float speed = 0;
    private Movement player;
    private Rigidbody rb;
    //Called before first frame
    private void Start()
    {
        //gets neccessary components from player
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        //sets max speed and speed
        maxspeed = player.maxspeed;
        speed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;
        //sets up slider
        speedSlider.maxValue = maxspeed;
        speedSlider.minValue = 0;
        speedSlider.value = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Updates slider
        speed = rb.velocity.magnitude;
        maxspeed = player.maxspeed;
        //upates  slider
        speedSlider.maxValue = maxspeed;
        speedSlider.value = speed;

        if (speed >= maxspeed / 2)
        {
            bar.color = new Color(bar.color.r + 2, bar.color.g - 1, bar.color.b, bar.color.a);
        }
        else if (bar.color.r >= 0)
        {
            bar.color = new Color(bar.color.r - 2, bar.color.g - 1, bar.color.b, bar.color.a);
        }
    }
}
