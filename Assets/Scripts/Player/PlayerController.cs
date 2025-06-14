using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputActionAsset playerActions;
    public int speed = 50;
    public float jumpForce = 5; // Fuerza del salto
    private InputActionMap playerMap;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 inputMove;
    private Rigidbody2D playerRb;
    private Animator playerAnimator; // Llama un Animator para manejar las animaciones
    private SpriteRenderer playerSpriteRenderer; // Llama un SpriteRenderer para manejar los sprites

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Awake()
    {
        playerMap = playerActions.FindActionMap("Player");
        moveAction = playerMap.FindAction("Move");
        jumpAction = playerMap.FindAction("Jump");
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); // inicializa al Animator
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); // inicializa al SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        inputMove = moveAction.ReadValue<Vector2>();
        Jump();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        playerRb.linearVelocityX = inputMove.x * speed * Time.deltaTime; // Movimiento solo en el eje X
        // Actualiza la animación del jugador según el movimiento
        if (inputMove.x == 0)
        {
            playerAnimator.SetBool("walk", false);
        }
        else
        {
            playerAnimator.SetBool("walk", true);
            if (inputMove.x < 0)
            {
                playerSpriteRenderer.flipX = true; // Voltea el sprite si se mueve a la izquierda
            }
            else
            {
                playerSpriteRenderer.flipX = false;
            }
        }
    }

    // Maneja el salto del jugador
    void Jump()
    {
        if (jumpAction.WasPressedThisFrame() && FootLogic.isGrounded)
        {
            playerRb.AddForceAtPosition(new Vector2(0, jumpForce), Vector2.up, ForceMode2D.Impulse); // Aplica una fuerza hacia arriba para el salto
            playerAnimator.SetTrigger("jump"); // Activa la animación de salto
        }
    }
}