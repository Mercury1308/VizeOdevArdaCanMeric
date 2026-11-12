using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //Karakterşn hızı

    private Rigidbody rb;

    [SerializeField] private float jumpForce = 7f; //Zıplama gücümüz

    private bool isGrounded; //Yerde miyiz onun kontrolü için

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //RB mizi tanımlıyoruz
    }



    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            //Space tuşuna basarsak ve eğer yere değiyorsak zıplama fonkisyonu calıssın
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
        //Değdimiz objenin tag ı ground ise , yerde olduğumuz anlamına gelsin
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        //Zemin ile teması kesinde false olsun ki havada zıplamayalım
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    void Jump()
    {
        //çift zıplamayı engellemek amacıyla y deki değeri 0 ladım diğerlerini ise aynı bıraktım
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        //Zıplama kuvvetini veren kısım
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}