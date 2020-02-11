using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public float jumpForce, speed;
    private Vector2 Left,Right;   
    public Animator anim,anim1,anim2;
    public bool isGrounded;
    public float health,timeelapsed;
    public float maxhealth = 100.0f;
    public Image healthimage;
    public GameObject Blood,powerpickup,Transition,objective;
    public string Scenename;
   // public GameObject bulletprefab;
  // public Shooting add;
    // Use this for initialization
    void Start () {
        objective.SetActive(true);
        health = maxhealth;
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Left = new Vector2(-x, y);
        Right = new Vector2(x, y);
        anim1 = Transition.GetComponent<Animator>();
        anim2 = objective.GetComponent<Animator>();
    }
    IEnumerator SceneChange()
    {
        anim1.SetTrigger("change");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(Scenename);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
            {
            StartCoroutine(SceneChange());
            }
        if(collision.gameObject.CompareTag("Plane1"))
            {
            StartCoroutine(SceneChange());
        }
        if(collision.gameObject.CompareTag("Spikes"))
        {
            health -= 20;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
           /* if(add.Bullets.Count < 8)
                {
                for (int i = 0; i < 4; i++)
                {
                    add.AddBullet(bulletprefab);
                }
            }*/
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       
    }
  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.gameObject.CompareTag("Health"))
        {
            Instantiate(powerpickup, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Powerup");
            if (health < 100)
            {
                health += 50;
                Destroy(collision.gameObject);
            }
            if (health >= 100)
            {
                health = 100;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("EnemyManBullet"))
        {
            if(health>0)
            {
                Instantiate(Blood, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("HitSound");
                health -=20;
            }
            anim.SetInteger("Health", (int)health);
        }
        if(collision.gameObject.CompareTag("TankBullet"))
        {
            if (health > 0)
            {
                Instantiate(Blood, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("HitSound");
                health -= 25;
            }
          anim.SetInteger("Health", (int)health);
        }
    }
    private void scenechange()
    {
        SceneManager.LoadScene("FirstScreen");
    }
    public void DestroyPlayer()
    {
      Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene("Gameover");
    }

    // Update is called once per frame
    void Update () {
        anim.SetFloat("Health", health);
        if(timeelapsed>3)
        {
            anim2.SetTrigger("trigger");
        }
        if(timeelapsed ==4 )
        {
            objective.SetActive(false);
        }
        else
        {
            timeelapsed += Time.deltaTime;
        }
        if (healthimage == null)
        {
            return;
        }
        else
        {
            healthimage.fillAmount = (health / maxhealth);
        }
            if (rb.velocity.x > 3)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else if(rb.velocity.x < -3)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        //float f = Mathf.Abs(rb.velocity.x);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.velocity = new Vector2(0, 0);
               
                rb.AddForce(new Vector2(0, jumpForce ));
                anim.SetTrigger("Jump");
            }
        }
         if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0)) ;
            transform.localScale = Right;
            //anim.SetFloat("Speed", rb.velocity.x);
        }
         if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce( new Vector2(-speed * Time.deltaTime, 0));
            transform.localScale = Left;
            //anim.SetFloat("Speed", -rb.velocity.x);
        }
         anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


    }
    
}
