using Unity.VisualScripting;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    private Animator fruitAnimator;
    public GameObject fruit;
    private AudioSource fruitAudioSource;
    private PlayerSettings playerSettings; // Configuración del jugador

    private void Awake()
    {
        fruitAnimator = GetComponent<Animator>();
        fruitAudioSource = GetComponent<AudioSource>();
        playerSettings = Resources.Load<PlayerSettings>("PlayerSettings"); // Carga la configuración del jugador desde los recursos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerSettings.score++; // Incrementa la puntuación del jugador
            fruitAudioSource.Play(); // Reproduce el sonido de recolección
            fruitAnimator.SetBool("isCollected", true);
            Destroy(fruit, 0.2f); // Destruye la fruta después de 0.2 segundos
        }
    }
}
