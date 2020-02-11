using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankattack : MonoBehaviour {
    public Shooting shoot;
    public GameObject TankBullet,Player,Tank;
    public Transform TankTrigger;
     float direction;
   // public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("TankAttack", 0f, 3f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("TankAttack");
        }
    }
    void TankAttack()
    {
        var temp =Instantiate(TankBullet, TankTrigger.position, TankTrigger.rotation);
        temp.GetComponent<TankBullet>().Setdirection(-transform.localScale.x);
        FindObjectOfType<AudioManager>().Play("TankBullet");
    }
   
    // Update is called once per frame
    void Update () {
		
	}
}
