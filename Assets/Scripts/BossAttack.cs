using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {
    public GameObject player,Bossobj,attack;
     Animator anim;
  
    public void stoptrigger()
    {
        attack.SetActive(false);
    }

    public void Bossattack()
    {
        anim.SetTrigger("attack");
        attack.SetActive(true);
    }
   
    // Use this for initialization
    void Start () {
        attack.SetActive(false);
        InvokeRepeating("Bossattack", 0f, 1.5f);
        anim = Bossobj.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
