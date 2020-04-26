using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengiun : MonoBehaviour
{
    [SerializeField] GameObject Bullet;

    Animator animator;
    bool isUp = false;
    bool isMiddle = false;
    bool isDown = false;
    float fireRate = 0.6f;
    float nextFire = -1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        float mouseY = mousePosition.y / Screen.height;
     // Debug.Log("Y" + mouseY);
        MovePenguinAnimation(mouseY);

        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
            return;
        } 
        else
        {  
            Shoot(mouseY);
        }  
    }

    void MovePenguinAnimation(float mousePosition)
    {

        if (mousePosition > 0.7f && isUp == false)
        {
            animator.SetBool("0ToIdle", true);
            animator.SetBool("idleTo45", true);
            animator.SetBool("45ToIdle", false);
            
            isUp = true;
            isMiddle = false;
        }
        else if (mousePosition <= 0.7f && isUp == true)
        {
            animator.SetBool("idleTo45", false);
            animator.SetBool("45ToIdle", true);
            isUp = false;

        }
        else if (mousePosition <= 0.7f && mousePosition >= 0.55f && isUp == false)
        {
            animator.SetBool("0ToIdle", true);
            animator.SetBool("IdleTo0", false);
            isMiddle = false;
        }
        else if (mousePosition < 0.55f && mousePosition > 0.40f && isMiddle == false)
        {
            animator.SetBool("0ToIdle", false);
            animator.SetBool("IdleTo0", true);
            isMiddle = true;
        }
        else if (mousePosition <= 0.40f && isDown == false)
        {
            animator.SetBool("IdleToDown", true);
            animator.SetBool("DownToIdle", false);
            animator.SetBool("IdleTo0", false);
            isDown = true;
            isMiddle = false;
        }
        else if (mousePosition > 0.40f && isDown == true)
        {
            animator.SetBool("DownToIdle", true);
            animator.SetBool("IdleToDown", false);
            isDown = false;
        }

    }

    public void Shoot(float mousePosition)
    {
        GameObject bullet;
        Rigidbody2D body;

        if (Input.GetButtonDown("Fire1"))
        {
            string direction = ResolveMousePosition(mousePosition);

            switch (direction)
            {
                case "UP":
                    animator.SetTrigger("ShootUp");
                    bullet = Instantiate(Bullet, new Vector3(-7.1f, 2.5f), Quaternion.Euler(0, 0, 32.2f)) as GameObject;
                    body = bullet.GetComponent<Rigidbody2D>();
                    body.velocity = new Vector2(75, 45);
                    body.angularVelocity = -1f;
                    break;
                case "DOWN":
                    animator.SetTrigger("ShootDown");
                    bullet = Instantiate(Bullet, new Vector3(-7f, 0.4f), Quaternion.Euler(0, 0, -29)) as GameObject;
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(20, -12);
                    break;
                default:
                    animator.SetTrigger("Shoot");
                    bullet = Instantiate(Bullet, new Vector3(-6.8f, 1.2f), Quaternion.Euler(0, 0, 0)) as GameObject;
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
                    break;
            }
            nextFire = fireRate;

        }

    }

    public string ResolveMousePosition(float mousePosition)
    {
        if (mousePosition > 0.55f)
        {
            return "UP";
        }
        else if (mousePosition <= 0.4f)
        {
            return "DOWN";
        }
        else
        {
            return "Straight";
        }
    }


}
