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

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float mouseY = Input.mousePosition.y / Screen.height;
        //Debug.Log(mouseY);
        MovePenguinAnimation(mouseY);
        Shoot(mouseY);
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

        if (Input.GetButtonDown("Fire1"))
        {
            string direction = ResolveMousePosition(mousePosition);

            switch (direction)
            {
                case "UP":
                    animator.SetTrigger("ShootUp");
                    break;
                case "DOWN":
                    animator.SetTrigger("ShootDown");
                    break;
                default:
                    animator.SetTrigger("Shoot");
                    break;
            }

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
