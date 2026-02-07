using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    private readonly Enemy _enemy;
    private readonly Movement _movement;
    private int _currentPointIndex = 0;
    private float _stopDistance = 0.1f;
    private float _time = 1f;
    private float _currentTime = 1f;
    private float _zero = 0;
    private Vector3 randomDirection = new();

    public EnemyState(Enemy enemy)
    {
        _enemy = enemy;
        _movement = _enemy.GetComponent<Movement>();
    }

    public void StateIdle(IdleBehaviorTypes idleBehaviorTypes)
    {
        switch (idleBehaviorTypes)
        {
            case IdleBehaviorTypes.None:
                None();
                break;
            case IdleBehaviorTypes.Patrol:
                Patrol();
                break;
            case IdleBehaviorTypes.RandomWalk:
                RandomWalk();
                break;
            default:
                Debug.Log("Такое состояние не поддерживается!");
                break;
        }
    }

    public void StateReaction(ReactionBehaviorTypes reactionBehaviorTypes)
    {
        switch (reactionBehaviorTypes)
        {
            case ReactionBehaviorTypes.Flee:
                Flee();
                break;
            case ReactionBehaviorTypes.Chase:
                Chase();
                break;
            case ReactionBehaviorTypes.Scare:
                Scare();
                break;
            default:
                Debug.Log("Такое состояние не поддерживается!");
                break;
        }
    }

    public void None()
    {
        Debug.Log("Я стою афк, меня не трогать!");
    }

    public void Patrol()
    {
        List<Transform> points = _enemy.PatrolPoints;

        if (points == null || points.Count == 0)
            return;

        Transform targetPoint = points[_currentPointIndex];

        Vector3 direction = targetPoint.position - _enemy.transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        if (distance < _stopDistance)
        {
            _currentPointIndex = (_currentPointIndex + 1) % points.Count;
        }
        else
        {
            _movement.Move(direction, _enemy.MoveSpeed);
            _movement.Rotate(direction, _enemy.RotationSpeed);
        }
    }

    public void RandomWalk()
    {
        if (_currentTime < _zero)
        {
            randomDirection = new(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            _currentTime = _time;
        }

        _movement.Move(randomDirection, _enemy.MoveSpeed);

        _currentTime -= Time.fixedDeltaTime;
    }

    public void Flee()
    {
        _movement.Move(-_enemy.SetDirectionToPlayer(), _enemy.MoveSpeed);
        _movement.Rotate(-_enemy.SetDirectionToPlayer(), _enemy.RotationSpeed);
    }

    public void Chase()
    {
        _movement.Move(_enemy.SetDirectionToPlayer(), _enemy.MoveSpeed);
        _movement.Rotate(_enemy.SetDirectionToPlayer(), _enemy.RotationSpeed);
    }

    public void Scare()
    {
        Debug.Log("< Умер от испуга >");
        _enemy.Die();
    }
}
