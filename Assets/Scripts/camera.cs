using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public GameObject player;
    public Vector3 offset;
    public float xMin = -1, xMax = 1;

    public static object main { get; internal set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            return;
        }
        else
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            transform.position = new Vector3(x, transform.position.y, transform.position.z) + offset;
        }
	}
}
