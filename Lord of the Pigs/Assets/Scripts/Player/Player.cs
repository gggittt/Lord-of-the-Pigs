using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour, IExplodable
{
    [SerializeField] private int _health = 5;
    private int Health
    {
        get => _health;
        set
        {
            if (value >= 0)
                _health = value;
            
        }
    }

    [SerializeField] private PlayerHealthUi _healthUi;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private GameOver _gameOverManager;


    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private float _bombInstallReloadTime = 2f;
    private float _bombInstallCooldown;

    private SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _bombInstallCooldown = _bombInstallReloadTime;
        _healthUi.UpdateHealth(Health);
    }

    private void Update()
    {
        _bombInstallCooldown -= Time.deltaTime;
    }

    public void GetBombEffect()
    {
        ChangeHealth(-1);
    }

    public void ChangeSpriteByDirection(LookDirectionType lookDirectionType)
    {
        _renderer.sprite = _sprites[(int) lookDirectionType];
    }

    public void ChangeHealth(int amount)
    {
        Health += amount;
        if (Health <= 0)
            _gameOverManager.Lose();
        _healthUi.UpdateHealth(Health);
    }

    

    public void TryInstallBomb()
    {
        if (_bombInstallCooldown <= 0)
        {
            InstallBomb();
            _bombInstallCooldown = _bombInstallReloadTime;
        }
    }

    private void InstallBomb()
    {
        var bomb = Instantiate(_bombPrefab);
        bomb.transform.position = transform.position;
    }
}