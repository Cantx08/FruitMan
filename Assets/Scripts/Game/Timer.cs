using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Componente TextMeshProUGUI para mostrar el tiempo
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;
    public float totalTime = 120f; // 2 minutos

    private float timeLeft;
    private bool isRunning = true;

    private void Awake()
    {
        timeLeft = totalTime;
        timerText.color = normalColor;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (!isRunning) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            isRunning = false;
            // Aquí puedes manejar lo que ocurre cuando el tiempo se acaba (ej: reiniciar nivel, mostrar mensaje, etc.)
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (timeLeft <= 20f)
            timerText.color = warningColor;
        else
            timerText.color = normalColor;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinicia el temporizador al cargar un nuevo nivel
        timeLeft = totalTime;
        isRunning = true;
        timerText.color = normalColor;
    }
}
