using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionscript : MonoBehaviour {
    public float elapsedtime=0f;
    public Animator anim;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(elapsedtime>5f)
        {
            SceneManager.LoadScene("FirstScreen");
        }
        else
        {
            elapsedtime += Time.deltaTime;
        }
	}
}
