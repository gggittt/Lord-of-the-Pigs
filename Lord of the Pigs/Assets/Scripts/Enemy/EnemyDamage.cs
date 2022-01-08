using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int  _damageAmount = 1;
    [SerializeField] float _targetTime = .5f;
    float _playerHoldTime;
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _playerHoldTime += Time.deltaTime;
            
            if (_playerHoldTime >= _targetTime)
            {
                player.ChangeHealth(-_damageAmount);
                _playerHoldTime = 0;
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _playerHoldTime = 0;
    }
    

}


