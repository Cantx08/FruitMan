using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Puntuación del jugador
    public PlayerSettings playerSettings; // Configuración del jugador
    public bool firstScene = false; // Indica si es la primera escena del juego
    public static GameManager instance;
    public List<Character> characters; // Personajes
    private static bool scoreInitialized = false;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("PlayerSettings"); // Carga la configuración del jugador desde los recursos

        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(this.gameObject); // Keep this object alive across scenes
            if (firstScene && !scoreInitialized)
            {
                playerSettings.score = 0; // Inicializa la puntuación del jugador SOLO UNA VEZ
                scoreInitialized = true;
            }
        }
        else
        {
            Destroy(gameObject); // Destruye instancias duplicadas
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerSettings.score + ""; // Actualiza el texto de la puntuación
    }
}
