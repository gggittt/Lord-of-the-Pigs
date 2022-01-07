using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private Joystick _joystick;

    private Rigidbody2D _rigidbody2D;
    private Player _player;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity;
#if UNITY_ANDROID
        velocity = new Vector2(
            _joystick.Horizontal, 
            _joystick.Vertical
        );
#endif
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        velocity = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
#endif
        
        _rigidbody2D.velocity = velocity * _moveSpeed;
    }

    private void Update()
    {
        //в отдельную функцию все про бомбу


        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.TryInstallBomb();
        }
    }
}