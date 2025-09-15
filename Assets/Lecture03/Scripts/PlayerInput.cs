using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float JumpPower = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && (isJumping == false) )
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * JumpPower;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
