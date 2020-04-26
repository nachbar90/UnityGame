using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bullet = collision.collider.gameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        var currentRotation = rb.transform.eulerAngles.z;
        //Debug.Log("rotation " + currentRotation);
        rb.SetRotation(currentRotation - Random.Range(80, 110));
    }
}
