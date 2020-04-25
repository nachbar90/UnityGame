using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengiun : MonoBehaviour
{

    Animator animator;
    bool isUp = false;
    bool isMiddle = false;
    bool isDown = false;
    float mousePreviousPosition = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.mousePosition.y / Screen.height;
        Debug.Log(mouseY);
        MovePenguinAnimation(mouseY);
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
            Debug.Log("W metodzie 1  boolean + " + isUp );
        }
        else if (mousePosition <= 0.7f && isUp == true)
        {
            Debug.Log("W metodzie 2 boolean + " + isUp);
            animator.SetBool("idleTo45", false);
            Debug.Log("bool " + animator.GetBool("idleTo45"));
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
          // animator.SetBool("0ToIdle", true);
           animator.SetBool("IdleToDown", true);
           animator.SetBool("DownToIdle", false);
           animator.SetBool("IdleTo0", false);
           isDown = true;
           isMiddle = false;
        }
        else if (mousePosition > 0.40f && isDown == true /*&& mousePosition > mousePreviousPosition*/)
        {
            animator.SetBool("DownToIdle", true);
            animator.SetBool("IdleToDown", false);
            isDown = false;
        }

        mousePreviousPosition = mousePosition;
    }

    /*void MovePenguinAnimation(float mousePosition)
    {

        if (mousePosition > 0.7f && isUp == false)
        {
            animator.SetBool("0ToIdle", true);
            animator.SetBool("idleTo45", true);
            animator.SetBool("45ToIdle", false);
            isUp = true;
            Debug.Log("W metodzie 1  boolean + " + isUp);
        }
        else if (mousePosition <= 0.7f && isUp == true)
        {
            Debug.Log("W metodzie 2 boolean + " + isUp);
            animator.SetBool("idleTo45", false);
            Debug.Log("bool " + animator.GetBool("idleTo45"));
            animator.SetBool("45ToIdle", true);
            isUp = false;

        }
        else if (mousePosition < 0.55f && mousePosition > 0.40f && isMiddle == false)
        {
            animator.SetBool("0ToIdle", false);
            animator.SetBool("IdleTo0", true);
            isMiddle = true;
        }
        else if (mousePosition <= 0.40f && isDown == false)
        {
            animator.SetBool("0ToIdle", true);
            animator.SetBool("IdleToDown", true);
            animator.SetBool("DownToIdle", false);
            animator.SetBool("IdleTo0", false);
            isDown = true;
            isMiddle = false;
        }
        else if (mousePosition > 0.40f && isDown == true && mousePosition > mousePreviousPosition)
        {
            animator.SetBool("DownToIdle", true);
            animator.SetBool("IdleToDown", false);
            isDown = false;
        }

        mousePreviousPosition = mousePosition;
    }
    */
}
