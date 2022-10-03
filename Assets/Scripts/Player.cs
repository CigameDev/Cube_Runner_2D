using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D m_rb;
    private bool m_isGrounded;
    private GameController m_gc;

    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc =FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if(isJumpKeyPressed && m_isGrounded)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGrounded = false;

            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }    
        }    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            if (aus && loseSound && !m_gc.IsGameOver())
            {
                aus.PlayOneShot(loseSound);
            }
            m_gc.SetGameOverState(true);
          
        }    
           
    }
}
