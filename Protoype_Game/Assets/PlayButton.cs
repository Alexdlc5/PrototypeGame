using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button playbutton;
    public GameObject ArenaModeButton;
    public GameObject InfinityModeButton;

    void Start()
    {
        Button button = playbutton.GetComponent<Button>();
        button.onClick.AddListener(Show);
    }

    //Shows buttons
    void Show()
    {
        ArenaModeButton.SetActive(true);
        InfinityModeButton.SetActive(true);
    }
}
