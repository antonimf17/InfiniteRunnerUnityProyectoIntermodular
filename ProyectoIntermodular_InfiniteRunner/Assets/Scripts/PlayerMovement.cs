using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    [Header("ParametrosIniciales")]
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody rb;

    [Header("Atributo movimiento horizontal")]
    [SerializeField] float horizontalInput;
    public float horizontalMultiplier = 2;


    private void FixedUpdate()
    {
        if (!alive) return;


        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);
    }



    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        //Restart the game
        Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
