using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator animator;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Zombie"))
        {
            animator = player.GetComponent<Animator>();
            animator.SetTrigger("Hurt");
            player.GetComponent<Pengiun>().PenguinWasHit();
        };
    }

}
