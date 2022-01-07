using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    //[SerializeField] private Player _player;
    [SerializeField] private Transform _target;
    [SerializeField] private WaitForSeconds _targetUpdateInterval = new WaitForSeconds(0.5f);

    private NavMeshAgent _agent;
    private Enemy _enemy;


    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        InitNavMesh2D();
        StartCoroutine(UpdateDestination());
        _agent.SetDestination(_target.position);
    }

    private IEnumerator UpdateDestination()
    {
        while (true)
        {
            yield return _targetUpdateInterval;
            _agent.SetDestination(_target.position);
        }
    }

    private void InitNavMesh2D()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    private void Update()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f); //это костыль т.к. не работает _agent.updateRotation = false; 

        Vector2Int direction = GetLookDirection();
        _enemy.UpdateDirectionSprite(direction);
    }

    private Vector2Int GetLookDirection()
    {
        var dir = transform.position - _target.position;
        var normalized = dir.normalized;

        if (dir.x > dir.y)
        {
            
        }

        return Vector2Int.one;
    }
}