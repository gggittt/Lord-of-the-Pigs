using UnityEngine;

public class CoupleMate : MonoBehaviour
{
    float _playerHoldTime;
    float _targetTime = 3f;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            _playerHoldTime = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _playerHoldTime += Time.deltaTime;

            if (_playerHoldTime >= _targetTime)
            {
                player.ChangeHealth(1);
                //LoveAnimation();
                Destroy(this);
            }
        }
    }
}