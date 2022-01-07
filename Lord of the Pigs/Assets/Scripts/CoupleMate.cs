using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleMate : MonoBehaviour
{
    float _playerHoldTime;
    float _targetTime = 3f;
    private bool _isStartingHoldPosition;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player) == false)
            return;
        _playerHoldTime = 0;
        _isStartingHoldPosition = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player) == false)
            return;

        _playerHoldTime += Time.deltaTime;

        if (_playerHoldTime >= _targetTime)
        {
            //playerHp++;
            //LoveAnimation();
            Destroy(this);
        }

        
    }
}