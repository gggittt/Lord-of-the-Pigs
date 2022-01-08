using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject  _endGamePanel;
    [SerializeField] private TextMeshProUGUI _text;
    
    public void Won()
    {
        _endGamePanel.SetActive(true);
        _text.text = "You Won!";
    }
    
    public void Lose()
    {
        _endGamePanel.SetActive(true);
        _text.text = "You lose!";
    }
}


