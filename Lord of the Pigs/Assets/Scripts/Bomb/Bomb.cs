using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _secondsBeforeExplosion = 3f;
    
    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_secondsBeforeExplosion);
        Explosion();
    }

    private void Explosion()
    {
        DoCircleRaycast();

        Destroy(gameObject, 0.3f);
    }

    private void DoCircleRaycast()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        //Rider suggests "Use non-allocating method 'OverlapCircleNonAlloc'", But Unity documentation has Note: This method will be deprecated in a future build and it is recommended to use OverlapCircle instead. //https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircleNonAlloc.html

        foreach (Collider2D point in colliders)
        {
            if (point.TryGetComponent(out IExplodable explodable))
            {
                explodable.GetBombEffect();
            }
        }
    }


    
}