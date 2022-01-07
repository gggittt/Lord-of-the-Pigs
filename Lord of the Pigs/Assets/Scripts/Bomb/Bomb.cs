using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _secondsBeforeExplosion = 3f;
    [SerializeField] private WaitForSeconds wfs = new WaitForSeconds(3);

    private Collider2D _bombCollider;
    private bool _shouldExplode;

    private void Start()
    {
        StartCoroutine(Countdown());
        _bombCollider = GetComponent<Collider2D>();
        //_bombCollider.bounds.SetMinMax();
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_secondsBeforeExplosion);
        Explosion();
    }

    private void Explosion()
    {
        _shouldExplode = true;

        DoRaycast();

        Destroy(gameObject, 0.3f);
    }

    private void DoRaycast()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        //Rider suggests "Use non-allocating method 'OverlapCircleNonAlloc'", But Unity documentation has Note: This method will be deprecated in a future build and it is recommended to use OverlapCircle instead. //https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircleNonAlloc.html

        foreach (Collider2D point in colliders)
        {
            if (point.TryGetComponent(out IExplodable explodable))
            {
                explodable.Explode();
            }

            Debug.Log($"<color=cyan> в радиусе бомбы = {point.name}  </color>");
        }
    }


    
}