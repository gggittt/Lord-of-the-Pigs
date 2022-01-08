using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishPlace : MonoBehaviour
{
    private GameOver _gameOver;

    private void Awake()
    {
        _gameOver = FindObjectOfType<GameOver>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GameWon();
        }
    }
    
    private void GameWon()
    {
        _gameOver.Won();
    }
}


