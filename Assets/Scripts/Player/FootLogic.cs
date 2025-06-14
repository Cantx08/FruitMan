using UnityEngine;

public class FootLogic : MonoBehaviour
{
    public static bool isGrounded = false; // Verifica si el personaje está en contacto con el suelo

    // Detectan el contacto del personaje con el suelo
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }

    // Detecta cuando el personaje sale del suelo
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
