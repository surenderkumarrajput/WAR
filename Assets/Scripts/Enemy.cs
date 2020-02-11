using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody2D Tank;
    public float TankHealth,max = 100;
    public Animator anim;
    public GameObject explosion,healthBar;
  
    private void Start()
    {
        TankHealth = max;
    }
    private void Tankdestroy()
    {
        FindObjectOfType<AudioManager>().Play("TankExplode");
        Destroy(Tank.gameObject);
    }
    public void DecreaseHealth(float health)
    {
        FindObjectOfType<AudioManager>().Play("TankHit");
        TankHealth -= health;
        healthBar.transform.localScale = new Vector2((TankHealth / max), healthBar.transform.localScale.y);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Bullet"))
        {
             if(TankHealth<=0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
               Tankdestroy();
            }
        }
    }
   
}

