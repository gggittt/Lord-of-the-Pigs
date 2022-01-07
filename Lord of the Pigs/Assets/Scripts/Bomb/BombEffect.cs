using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.3f);

    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"<color=cyan> Trigger {other} </color>");
        Destroy(other.gameObject);
        
    }

}


