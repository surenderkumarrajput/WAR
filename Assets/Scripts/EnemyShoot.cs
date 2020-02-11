using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject BulletEnemy;
    public GameObject triggerpoint;
	// Use this for initialization
	void Start () {
        
    }
	void EnemyAttack()
    {
        FindObjectOfType<AudioManager>().Play("Shot");
       var temp= Instantiate(BulletEnemy, triggerpoint.transform.position, triggerpoint.transform.rotation);
        temp.GetComponent<EnemyBullet>().SetDirection(transform.localScale.x);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            {
            InvokeRepeating("EnemyAttack", 0f, 2f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("EnemyAttack");
        }
    }
    // Update is called once per frame
    void Update () {
        
	}
}
