using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//spawns player at designated location
public class Respawn : MonoBehaviour
{
    public Button ResButton;
    public string location;

    void Start()
    {
        Button button = ResButton.GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(location);
        Time.timeScale = 1;
    } 
}
