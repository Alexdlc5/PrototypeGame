using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject InstructionOne;
    public GameObject InstructionTwo;
    public GameObject InstructionThree;
    public GameObject InstructionFour;
    private bool StageOne = true;
    private bool StageTwo = false;
    private bool StageThree = false;
    private bool StageFour = false;

    // Update is called once per frame
    void Update()
    {
        if (StageOne)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                StageTwo = true;
                Destroy(InstructionOne);
                InstructionTwo.SetActive(true);
                StageOne = false;
                Destroy(InstructionOne);
            }
        }
        else if (StageTwo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StageThree = true;
                Destroy(InstructionTwo);
                InstructionThree.SetActive(true);
                StageTwo = false;
            }

        }
        else if (StageTwo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StageFour = true;
                Destroy(InstructionThree);
                InstructionFour.SetActive(true);
                StageThree = false;
            }

        }
        else if (StageTwo)
        {

        }
    }
}
