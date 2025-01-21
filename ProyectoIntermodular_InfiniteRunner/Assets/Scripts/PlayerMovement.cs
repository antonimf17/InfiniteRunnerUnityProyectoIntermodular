using UnityEngine;

public class Script : MonoBehaviour
{
    [Header("ParametrosIniciales")]
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody rb;

    [Header("Atributo movimiento horizontal")]
    [SerializeField] float horizontalInput;
    public float horizontalMultiplier = 2;


    private void FixedUpdate()
    {
        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);
    }



    // Update is called once per frame
   private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
