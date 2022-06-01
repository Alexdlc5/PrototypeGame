using UnityEngine;

//opens pause menu
public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeInHierarchy); 
        }
    }
}
