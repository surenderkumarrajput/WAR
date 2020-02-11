using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRight : MonoBehaviour {
    public EnemyMan Man;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyMan"))
        {
            Man.flipRight();
        }
    }
}
