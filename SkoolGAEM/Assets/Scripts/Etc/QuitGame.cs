using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button ResButton;

    void Update()
    {
        Button button = ResButton.GetComponent<Button>();
        button.onClick.AddListener(quitGame);
    }

    void quitGame()
    {
        Application.Quit();
    }
}
