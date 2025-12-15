using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExpoloreEnding()
    {
        SceneManager.LoadScene(5);
    }
}