using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform Triggerpoint;
    public GameObject bulletprefab;
    public Animator animator;
    public Shake shake;
    bool Shootingbool=true;
  // public  List<GameObject> Bullets = new List<GameObject>();
   
    // Use this for initialization
    void Start () {
       
	}
   /*public void BulletDestroy(GameObject bullet)
    {
        Bullets.Remove(bullet);
    }
    public void AddBullet(GameObject bullet)
    {
        Bullets.Add(bullet);
    }*/
  void Boolcondition()
    {
        Shootingbool = true;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (Shootingbool == true)
            {
                Shootingbool = false;
                FindObjectOfType<AudioManager>().Play("Shot");
                var temp = Instantiate(bulletprefab, Triggerpoint.position, Triggerpoint.rotation) as GameObject;
                temp.GetComponent<Bullet>().SetDirection(transform.localScale.x);
                animator.SetBool("Shooting", true);
                shake.camshake();
                Invoke("Boolcondition", 1f);
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Shooting", false);
        }
       
    }
}
