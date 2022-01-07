using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour, IExplodable
{

    [SerializeField] private int _health = 5;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private float _bombInstallReloadTime = 2f;
    private float _bombInstallCooldown;

    private void Awake()
    {
        _bombInstallCooldown = _bombInstallReloadTime;
    }

    private void Update()
    {
        _bombInstallCooldown -= Time.deltaTime;
    }

    private void InstallBomb()
    {
        var bomb = Instantiate(_bombPrefab);
        bomb.transform.position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log($"<color=cyan> {other.gameObject.name}  </color>");
    }

    public void TryInstallBomb()
    {
        if (_bombInstallCooldown <= 0)
        {
            InstallBomb();
            _bombInstallCooldown = _bombInstallReloadTime;
        }
    }

    public void Explode()
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        _health--;
    }
}
