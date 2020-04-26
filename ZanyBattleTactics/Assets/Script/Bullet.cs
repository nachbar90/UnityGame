using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private int _hits = 1;
    public int MyProperty { get; set; }

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public int Hits
    {
        get
        {
            return _hits;
        }
        set
        {
            _hits = value;
        }
    }

    public void DecreaseBulletLife()
    {
        _hits -= 1;
    }

    public IEnumerator InvokeBulletExplosionAnimationAndDestroyObject(GameObject gameObject)
    {
        animator.SetTrigger("BulletExplosion");
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }

}
