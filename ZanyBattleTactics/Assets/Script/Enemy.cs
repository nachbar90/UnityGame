using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    private EnemyConfiguration _enemyConfiguration;
    public EnemyConfiguration EnemyConfiguration { get { return _enemyConfiguration; } set { _enemyConfiguration = value;  } }
    int i = 0;
    Animator animator;

    void Start()
    {
        points = _enemyConfiguration.Points();
        transform.position =  points[i].transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (i < points.Count)
        {
            var target = points[i].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * _enemyConfiguration.EnemySpeed);

            if (transform.position == target)
            {
                i++;
            }
                
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (gameObject.tag.Equals("Bat"))
            {
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 4f;
                animator.SetTrigger("BatDeath");
            }
            else
            {
                StartCoroutine(InvokeExplosionAnimationAndDestroyZombieObject(gameObject));
            }

        }

    }

    public IEnumerator InvokeExplosionAnimationAndDestroyZombieObject(GameObject gameObject)
    {
        var animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Explosion");
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
