using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishPlace : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GameWon();
        }
    }
    
    private void GameWon()
    {
        Debug.Log($"<color=green> Trigger Finish </color>");
    }
}


