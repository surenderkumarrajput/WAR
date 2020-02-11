using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSword : MonoBehaviour {
    public Image healthimage;
   public Rigidbody2D rb;
    private bool isGrounded = true;
     float health,maxhealth=100;
    public float jumpForce,speed,timeelapsed;
    public Animator anim,anim2;
    Vector2 Right, Left;
    public Boss boss;
    public GameObject sword,Effect,BloodEffect,objective;
   private IEnumerator Swordattack()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        sword.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bossattack"))
        {
            health -= 25;
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            if (health < 100)
            {
                health += 50;
            }
            if(health>=100)
            {
                health = 100;
            }
            Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
    private void Start()
    {
        Invoke("objectiveon", 1);
        sword.SetActive(false);
        health = maxhealth;
        Right = new Vector2(transform.localScale.x, transform.localScale.y);
        Left = new Vector2(-transform.localScale.x, transform.localScale.y);
        anim2 = objective.GetComponent<Animator>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boss"))
        {
            health -= 30;
            Instantiate(BloodEffect, transform.position, Quaternion.identity);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Spikes"))
        {
            Instantiate(BloodEffect, transform.position, Quaternion.identity);
            health -= 20;
        }
    }
  void objectiveon()
    {
        objective.SetActive(true);
    }
        
        
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void Playerdestroy()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene("Gameover");
    }
    void Update()
    {
        anim.SetFloat("health", health);
        if (timeelapsed > 3)
        {
            anim2.SetTrigger("trigger");
        }
        if (timeelapsed == 4)
        {
            objective.SetActive(false);
        }
        else
        {
            timeelapsed += Time.deltaTime;
        }
        if (health<=0)
        {
            anim.SetTrigger("Die");
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Swordattack());
            anim.SetTrigger("attack");
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
        else if (rb.velocity.x < -3)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        //float f = Mathf.Abs(rb.velocity.x);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.velocity = new Vector2(0, 0);

                rb.AddForce(new Vector2(0, jumpForce));
                anim.SetTrigger("Jump");
            }
        }
      
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
            transform.localScale = Right;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            transform.localScale = Left;
            
        }
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));


    }

}
