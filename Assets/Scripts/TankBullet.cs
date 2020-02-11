using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed,direction;
	// Use this for initialization
	void Start () {
        Invoke("Destroy", 5f);
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = new Vector2(speed * Time.deltaTime*direction, 0);
        rb.transform.localScale = new Vector2(transform.localScale.x * direction, transform.localScale.y);
    }
    private void Destroy()
    {
        Destroy(rb.gameObject);
    }
   public void Setdirection(float direction)
    {
        this.direction = direction;
    }
}
