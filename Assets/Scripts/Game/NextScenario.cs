using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenario : MonoBehaviour
{
    public GameObject fruits;
    private AudioSource winSound;
    public int sceneNumber = 1;
    
    private void Awake()
    {
        winSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && fruits.transform.childCount == 0)
        {
            winSound.Play();
            Invoke("NextLevel", 0.3f);

        }
    }


    private void NextLevel()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
