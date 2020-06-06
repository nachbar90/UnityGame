using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Pengiun : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] List<GameObject> healthPointsObjects;

    public int healthPoints = 3;

    Animator animator;
    bool isUp = false;
    bool isMiddle = false;
    bool isDown = false;
    float fireRate = 0.65f;
    float nextFire = -1f;


    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;   
        float mouseY = mousePosition.y / Screen.height;
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
        else if (mousePosition <= 0.7f && mousePosition >= 0.60f && isUp == false)
        {
            animator.SetBool("0ToIdle", true);
            animator.SetBool("IdleTo0", false);
            isMiddle = false;
        }
        else if (mousePosition < 0.60f && mousePosition > 0.40f && isMiddle == false)
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
                    body.velocity = new Vector2(25, 15);
                    body.angularVelocity = -1f;
                    break;
                case "DOWN":
                    animator.SetTrigger("ShootDown");
                    bullet = Instantiate(Bullet, new Vector3(-7f, 0.4f), Quaternion.Euler(0, 0, -29)) as GameObject;
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(27, -12);
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
        if (mousePosition > 0.6f)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bat"))
        {
            PenguinWasHit();
        }
    }

    public void PenguinWasHit()
    {
        healthPoints -= 1;
        RemoveHeartPoint();

        if (healthPoints != 0)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            animator.SetTrigger("Death");
            StartCoroutine(InvokeGameOver());
        }
    }

    public void RemoveHeartPoint()
    {
        if (healthPointsObjects.Count != 0)
        {
            var lastIndex = healthPointsObjects.Count - 1;
            var point = healthPointsObjects.ElementAt(lastIndex);
            Destroy(point);
            healthPointsObjects.RemoveAt(lastIndex);
        }
    }

    public IEnumerator InvokeGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }


}
