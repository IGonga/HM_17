using UnityEngine;

public class Chase : IBehavior
{
    private readonly EnemyDetector _enemyDetector;
    private readonly Movement _movement;

    public Chase(EnemyDetector enemyDetector, Movement movement)
    {
        _enemyDetector = enemyDetector;
        _movement = movement;
    }

    public void Enter()
    {
        Debug.Log("Вхожу в состояние - Chase");
    }

    public void Execute()
    {
        StartChase();
    }

    public void Exit()
    {
        Debug.Log("Выхожу из состояния - Chase");
    }

    private void StartChase()
    {
        Transform target = _enemyDetector.Target;

        if (target == null)
            return;

        Vector3 direction = target.position - _enemyDetector.transform.position;
        direction.y = 0;

        _movement.Move(direction, _movement.MoveSpeed);
        _movement.Rotate(direction, _movement.RotateSpeed);
    }
}
