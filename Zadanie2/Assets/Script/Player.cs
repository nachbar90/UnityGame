using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    Animator animator;
    Rigidbody2D rb;
    Collider2D collider;
    bool hasKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Walk();
        RotatePlayer();
        Jump();
    }

    private void Walk()
    {
        float movementX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
    }

    private void RotatePlayer()
    {
        bool isPlayerMoving = Mathf.Abs(rb.velocity.x) > 0;
        if (isPlayerMoving)
        {
            animator.SetBool("walk", true);
            float current = transform.localScale.x;
            Debug.Log("float" + current);
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x) + (Mathf.Sign(rb.velocity.x) / 2), 1.5f);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    private void Jump()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Foreground")) && Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0f, jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider.gameObject;
        if (collider.tag.Equals("Gem"))
        {
            Destroy(collider);
        }
        else if (collider.tag.Equals("Key"))
        {
            hasKey = true;
            Destroy(collider);
        }
        else if (collider.tag.Equals("Exit"))
        {
            if (hasKey)
            {
                SceneManager.LoadScene("Win");
            }
        }

        else if (collider.tag.Equals("Cactus")  || collider.tag.Equals("Lava"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
