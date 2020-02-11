using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    private float direction;
    public Animator anim;
    public float EnemyManH = 100;
    public Shooting shoot;
    public GameObject destroyanimation,Blood;
    // Use this for initialization
    void Start () {
        Invoke("Destroy", 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyMan"))
        {
            collision.gameObject.GetComponent<EnemyMan>().DecreaseHealth(25);
            //shoot.BulletDestroy(gameObject);
            Instantiate(Blood, transform.position, transform.rotation);
            Destroy(gameObject);
           
        }
        if (collision.gameObject.CompareTag("Tank"))
        {
            collision.gameObject.GetComponent<Enemy>().DecreaseHealth(20);
           //shoot.BulletDestroy(gameObject);
            Instantiate(destroyanimation, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
    
    // Update is called once per frame
    void Update ()
    {
        rb.velocity = Vector2.right * speed*direction*Time.deltaTime;
    }
    public void SetDirection(float direction)
    {
        this.direction = direction;
    }
    public void Destroy()
    {   
        Destroy(gameObject);
    }
}
