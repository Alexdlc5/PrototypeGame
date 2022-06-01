using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    //text
    public GameObject InstructionOne;
    public GameObject InstructionTwo;
    public GameObject InstructionThree;
    public GameObject InstructionFour;
    public GameObject InstructionFive;
    public GameObject InstructionSix;
    public GameObject InstructionSeven;
    //what stage tutorial on
    private bool StageOne = true;
    private bool StageTwo = false;
    private bool StageThree = false;
    private bool StageFour = false;
    private bool StageFive = false;
    private bool StageSix = false;
    public bool StageSeven = false;


    // Update is called once per frame
    void Update()
    {
        //format
        //if (StageX)
        //  if (Instruction Complete)
        //     Activate next step, pushes current instruction off screen, destroys current instruction, actives nexts instructions gameobject, go to next stage
        if (StageOne)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                StageTwo = true;
                InstructionOne.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionOne, 1);
                InstructionTwo.SetActive(true);
                StageOne = false;
            }
        }
        else if (StageTwo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StageThree = true;
                InstructionTwo.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionTwo, 1);
                InstructionThree.SetActive(true);
                StageTwo = false;
            }

        }
        else if (StageThree)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StageFour = true;
                InstructionThree.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionThree, 1);
                InstructionFour.SetActive(true);
                StageThree = false;
            }

        }
        else if (StageFour)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StageFive = true;
                InstructionFour.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionFour, 1);
                InstructionFive.SetActive(true);
                StageFour = false;
            }
        }
        else if (StageFive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StageSix = true;
                InstructionFive.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionFive, 1);
                InstructionSix.SetActive(true);
                StageFive = false;
            }
        }
        else if (StageSix)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StageSeven = true;
                InstructionSix.GetComponent<Rigidbody>().AddForce(Vector3.up * -10000);
                Destroy(InstructionFive, 1);
                InstructionSeven.SetActive(true);
                StageSix = false;
            }
        }
    }
}
