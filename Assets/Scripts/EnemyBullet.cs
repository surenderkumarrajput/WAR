using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;
    private float direction;
  
	// Use this for initialization
	void Start () {
        Invoke("BulletDestroy", 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = Vector2.right*speed * Time.deltaTime*direction;
        transform.localScale *= direction;
	}
    public void SetDirection(float direction)
    {
        this.direction = direction;
    }
    void BulletDestroy()
    {
        Destroy(rb.gameObject);
    }
    
}
