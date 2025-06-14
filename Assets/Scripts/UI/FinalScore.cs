using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class FinalScore : MonoBehaviour
{
    private PlayerSettings playerSettings; // Referencia a la configuración del jugador
    public TextMeshProUGUI scoreText; // Puntuación del jugador

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("PlayerSettings");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = playerSettings.score + ""; // Muestra la puntuación del jugador en el UI
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
