using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    //[SerializeField] private Player _player;
    [SerializeField] private Transform _target;
    [SerializeField] private float _targetUpdateInterval = .5f;
    private WaitForSeconds _targetUpdateIntervalSeconds;

    private NavMeshAgent _agent;
    private Enemy _enemy;

    private IEnumerator _updateDestinationCoroutine;

    private void Awake()
    {
        _targetUpdateIntervalSeconds = new WaitForSeconds(_targetUpdateInterval);
        _enemy = GetComponent<Enemy>();
        InitNavMesh2D();
        _updateDestinationCoroutine = UpdateDestination();
        StartCoroutine(_updateDestinationCoroutine);
        _agent.SetDestination(_target.position);
    }

    private void Update()
    {
        transform.rotation =
            new Quaternion(0f, 0f, 0f, 0f); //это костыль т.к. не работает _agent.updateRotation = false; 

        var direction = GetLookDirection();
        _enemy.UpdateDirectionSprite(direction);
    }

    public IEnumerator Stun(float stunSeconds)
    {
        FreezeMoving();
        void FreezeMoving()
        {
            StopCoroutine(_updateDestinationCoroutine);
            _agent.SetDestination(transform.position);
        }

        yield return new WaitForSeconds(stunSeconds);
        StartCoroutine(_updateDestinationCoroutine);
    }

    private IEnumerator UpdateDestination()
    {
        while (true)
        {
            yield return _targetUpdateIntervalSeconds;
            _agent.SetDestination(_target.position);
        }
    }

    private void InitNavMesh2D()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    private LookDirectionType GetLookDirection()
    {
        var dir = _target.position - transform.position;

        return CalculateDirection.GetDir(dir);
    }
}