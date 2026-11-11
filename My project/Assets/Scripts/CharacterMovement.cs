using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;// Bir sonraki zıplama için zaman sayacı

    [SerializeField] private float jumpForce = 7f; // Zıplama kuvveti

    [Header("Zemin Kontrolü (isGrounded)")]
    [SerializeField] private Transform groundCheck; // Ayak hizasındaki boş bir GameObject
    [SerializeField] private float groundDistance = 0.4f; // Kontrol küresinin yarıçapı
    [SerializeField] private LayerMask groundMask; // Zeminin katmanı (Layer)
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {


        // Z tuşuna veya Space tuşuna basıldığında ve yerdeyken zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * moveSpeed, ForceMode.Acceleration);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    void Jump()
    {
        // Y eksenindeki mevcut hızını sıfırlayarak her zıplamada aynı yüksekliğe çıkmasını sağla
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Yukarı yönlü kuvvet uygula
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}