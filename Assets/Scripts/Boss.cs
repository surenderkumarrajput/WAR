using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    public PlayerSword player;
   public float health,max=100f;
    public Image healthbar;
    public Animator anim;
    public GameObject attack;
    void Start () {
        health = max;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("Sword"))
        {
            FindObjectOfType<Shake>().camshake();
            FindObjectOfType<AudioManager>().Play("TankHit");
            health -= 10;
        }
    }
    
    public void stoptrigger()
    {
        attack.SetActive(false);
    }
    public void DestroyMethod()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameFinish");
    }
    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (health / max);
        if(health<=0)
        {
            anim.SetFloat("Health", health);
        }
    }  
}
