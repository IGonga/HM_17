using UnityEngine;

public class Flee : IBehavior
{
    private readonly EnemyDetector _enemyDetector;
    private readonly Movement _movement;

    public Flee(EnemyDetector enemyDetector, Movement movement)
    {
        _enemyDetector = enemyDetector;
        _movement = movement;
    }

    public void Execute()
    {
        StartFlee();
    }

    private void StartFlee()
    {
        Transform target = _enemyDetector.Target;

        if (target == null)
            return;

        Vector3 direction = target.position - _enemyDetector.transform.position;
        direction *= -1;
        direction.y = 0;

        _movement.Move(direction, _movement.MoveSpeed);
        _movement.Rotate(direction, _movement.RotateSpeed);
    }
}
