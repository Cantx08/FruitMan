using UnityEngine;

public class SeriousFruitController : MonoBehaviour
{
    public bool isCorrect = false;
    public int points = 1;
    private Animator fruitAnimator;
    private AudioSource audioSource;
    private PlayerSettings playerSettings;
    public GameObject seriousFruit;

    private void Awake()
    {
        fruitAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerSettings = Resources.Load<PlayerSettings>("PlayerSettings");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            if (!isCorrect)
            {
                playerSettings.score = playerSettings.score - points;
            }
            else
            {
                playerSettings.score = playerSettings.score + points;
            }
            fruitAnimator.SetBool("isCollected", true);
            Destroy(seriousFruit, 0.2f);
        }
    }
}
