using System.Collections.Generic;
using UnityEngine;

public class Patrol : IBehavior
{
    private readonly Transform _transform;
    private readonly Movement _movement;
    private readonly List<Transform> _targets;
    private readonly float _stopDistance = 0.1f;
    private int _currentPointIndex = 0;

    public Patrol(Transform enemyTransform, Movement movement, List<Transform> targets)
    {
        _transform = enemyTransform;
        _movement = movement;
        _targets = targets;
    }

    public void Enter()
    {
        Debug.Log("Вхожу в состояние - Patrol");
    }

    public void Execute()
    {
        StartPatrol();
    }

    public void Exit()
    {
        Debug.Log("Выхожу из состояния - Patrol");
    }

    private void StartPatrol()
    {
        List<Transform> points = _targets;

        if (points == null || points.Count == 0)
            return;

        Transform targetPoint = points[_currentPointIndex];

        Vector3 direction = targetPoint.position - _transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        if (distance < _stopDistance)
        {
            _currentPointIndex = (_currentPointIndex + 1) % points.Count;
        }
        else
        {
            _movement.Move(direction, _movement.MoveSpeed);
            _movement.Rotate(direction, _movement.RotateSpeed);
        }
    }
}
