using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SpeedBar : MonoBehaviour
{
    public Slider speedSlider;
    public TextMeshProUGUI textMesh;
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
        maxspeed = player.maxspeed = 35;
        speed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;
        //sets up slider
        speedSlider.maxValue = 50;
        speedSlider.minValue = 0;
        speedSlider.value = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Updates slider
        speed = rb.velocity.magnitude;
        //upates  slider
        speedSlider.maxValue = maxspeed;
        speedSlider.value = speed;
        //updates speed number
        textMesh.text = "Speed: [                                                      ] " + Math.Truncate(speed);
    }
}
