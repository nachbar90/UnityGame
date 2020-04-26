using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWall : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bulletGameObject = collision.collider.gameObject;
        var bullet = bulletGameObject.GetComponent<Bullet>();
        Rigidbody2D rb = bulletGameObject.GetComponent<Rigidbody2D>();

        if (bullet.Hits == 0)
        {
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
            rb.angularVelocity = 0f;
            rb.simulated = false;
            StartCoroutine(bullet.InvokeBulletExplosionAnimationAndDestroyObject(bulletGameObject));
        }

        bullet.DecreaseBulletLife();
        var currentRotation = rb.transform.eulerAngles.z;
        rb.SetRotation(currentRotation - Random.Range(80, 110));
    }
}
