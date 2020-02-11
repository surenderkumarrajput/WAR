using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paneloffscript : MonoBehaviour {
    public GameObject panel;
	// Use this for initialization
	void Start () {
        Invoke("paneloff", 1.8f);
	}
	private void paneloff()
    {
        panel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
