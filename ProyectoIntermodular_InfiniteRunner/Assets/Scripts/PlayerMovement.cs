using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    [Header("Parámetros Iniciales")]
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    [Header("Movimiento Horizontal")]
    [SerializeField] float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;

    [Header("Atributos de Salto")]
    public float normalJumpForce = 10f;
    public float boostedJumpForce = 20f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float groundcheckRadius = 0.3f;

    [Header("Stamina")]
    public StaminaBar staminaBar;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);
    }

    private void Update()
    {
        groundCheck();
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    void groundCheck()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.2f, groundMask);
    }


    public void Die()
    {
        if (!alive) return;
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        // Solo permite saltar si el jugador está tocando el suelo
        if (isGrounded && rb.velocity.y <= 0.1f)
        {
            float jumpForce = normalJumpForce;  // Comienza con el salto normal

            // Si el jugador tiene suficiente estamina, hace un salto más fuerte
            if (staminaBar.GetCurrentStamina() >= 50f && Input.GetKey(KeyCode.W))
            {
                jumpForce = boostedJumpForce;  // Si tiene 50 o más de estamina, aumenta el salto
                staminaBar.UseStamina(50f);  // Consume 50 de estamina
            }

            // Ejecuta el salto con la fuerza determinada
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

}
