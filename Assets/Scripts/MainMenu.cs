using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame ()
    {
        SceneManager.LoadScene("Playground");
    }
}
