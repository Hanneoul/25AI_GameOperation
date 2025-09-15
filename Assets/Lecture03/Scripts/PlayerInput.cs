using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    public float JumpPower = 1.0f;
    public float RotatePower = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    bool isJumping = false;

    
    float angle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ȸ��
        if (isJumping == true)
        {
            transform.Rotate(0, 0, angle);
            angle = +RotatePower * 0.1f;
        }
        
        //����
        if (Keyboard.current.spaceKey.wasPressedThisFrame && (isJumping == false) )
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * JumpPower;         
        }
    }

    
}
