using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, IExplodable
{

    [SerializeField] private float  _stunSeconds = 2f;
    [SerializeField] private Sprite[] _spritesCasual;
    [SerializeField] private Sprite[] _spritesDirty;
    [SerializeField] private Sprite[] _spritesAngry;
    private int _spriteIndex;
    private SpriteRenderer _renderer;

    private EnemyPhaseType _enemyPhaseType = EnemyPhaseType.Casual;

    private Dictionary<EnemyPhaseType, Sprite[]> _phaseSpritePair;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _phaseSpritePair = new Dictionary<EnemyPhaseType, Sprite[]>()
        {
            {EnemyPhaseType.Casual, _spritesCasual},
            {EnemyPhaseType.Dirty, _spritesDirty},
            {EnemyPhaseType.Angry, _spritesAngry},
        };
    }
    
    public void UpdateDirectionSprite(Vector2Int targetPosition)
    {
        var spriteSet = _phaseSpritePair[_enemyPhaseType];

        var direction = GetDirection(targetPosition);
        _renderer.sprite = spriteSet[direction];
    }
    
    private int GetDirection(Vector2Int targetPosition)
    {
        return 2;
    }

    public void Explode()
    {
        StartCoroutine(Stun());
    }

    private IEnumerator Stun()
    {
        SetDirtySpriteSet();
        yield return new WaitForSeconds(_stunSeconds);
        BecameAngry();
    }

    private void BecameAngry()
    {
        _enemyPhaseType = EnemyPhaseType.Angry;
        SetAngrySpriteSet();
    }

    private void SetAngrySpriteSet()
    {
        throw new NotImplementedException();
    }

    private void SetDirtySpriteSet()
    {
        throw new NotImplementedException();
    }

    
}


