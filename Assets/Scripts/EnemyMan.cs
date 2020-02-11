using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMan : MonoBehaviour
{
    public Rigidbody2D rb;
    public Bullet EnemyMan1;
    public Animator anim;
    public float speed;
    public GameObject healthBar,player;
    
    private float health ,max=100;
    private void Start()
    {
        health = max;
      rb.velocity =  Vector2.left*speed*Time.deltaTime;
    }
    private void Update()
    {
        anim.SetFloat("speed", speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0, 0);
            speed = 0f;
            if(transform.localScale.x==-player.transform.localScale.x)
            {
                return;
            }
            else if(transform.localScale.x == player.transform.localScale.x)
                transform.localScale = new Vector2(-player.transform.localScale.x, transform.localScale.y);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       /// Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Bullet"))
        {
           
        }
        
    }
    public void flipLeft()
    {
       
            rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        
        }

    public void flipRight()
    {
       
       
            rb.velocity = (new Vector2(speed * Time.deltaTime, 0));
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        
        }
    public void DestroyEnemyMan()
    {
      
        Destroy(rb.gameObject);
    }
   
    public void DecreaseHealth(int factor)
    {
        if (health > 0)
        {
            FindObjectOfType<AudioManager>().Play("HitSound");
            health -= factor;
            healthBar.transform.localScale = new Vector2((health / max), healthBar.transform.localScale.y);
        }

        anim.SetFloat("EnemyManHealth", health);
        Debug.Log(health);

    }
}
