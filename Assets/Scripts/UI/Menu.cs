using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int menuID = 0;
    public int levelID = 1;
    public void StartGame()
    {
        SceneManager.LoadScene(levelID);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}