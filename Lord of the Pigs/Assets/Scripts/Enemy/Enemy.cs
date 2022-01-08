using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(EnemyMove))]
public class Enemy : MonoBehaviour, IExplodable
{

    [SerializeField] private float  _stunSeconds = 2f;
    [SerializeField] private Sprite[] _spritesCasual;
    [SerializeField] private Sprite[] _spritesDirty;
    [SerializeField] private Sprite[] _spritesAngry;
    private int _spriteIndex;
    private SpriteRenderer _renderer;
    private EnemyMove _enemyMove;

    private EnemyPhaseType _phaseType = EnemyPhaseType.Casual;
    private LookDirectionType _lookDirectionType = LookDirectionType.Left;

    private Dictionary<EnemyPhaseType, Sprite[]> _phaseSpritePair;

    private void Awake()
    {
        _enemyMove = GetComponent<EnemyMove>();
        _renderer = GetComponent<SpriteRenderer>();
        _phaseSpritePair = new Dictionary<EnemyPhaseType, Sprite[]>()
        {
            {EnemyPhaseType.Casual, _spritesCasual},
            {EnemyPhaseType.Dirty, _spritesDirty},
            {EnemyPhaseType.Angry, _spritesAngry},
        };
    }
    
    public void UpdateDirectionSprite(LookDirectionType lookDirectionType)
    {
        _lookDirectionType = lookDirectionType;
        UpdateSprite();
    }
    
    private void UpdateSprite()
    {
        var spriteSet = _phaseSpritePair[_phaseType];

        _renderer.sprite = spriteSet[(int) _lookDirectionType];
    }

    public void GetBombEffect()
    {
        StartCoroutine(Stun());
    }

    private IEnumerator Stun()
    {
        BecameDirty();
        StartCoroutine(_enemyMove.Stun(_stunSeconds));
        yield return new WaitForSeconds(_stunSeconds);
        BecameAngry();
    }

    private void ChangePhaseAndSprite(EnemyPhaseType phase)
    {
        _phaseType = phase;
        UpdateSprite();
    }
    private void BecameAngry() => ChangePhaseAndSprite(EnemyPhaseType.Angry);
    private void BecameDirty() => ChangePhaseAndSprite(EnemyPhaseType.Dirty);
}


