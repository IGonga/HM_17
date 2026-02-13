using UnityEngine;

public class RandomWalk : IBehavior
{
    private readonly Movement _movement;
    private readonly float _time = 1f;
    private readonly float _zero = 0;
    private float _currentTime = 1f;
    private Vector3 randomDirection = new();

    public RandomWalk(Movement movement)
    {
        _movement = movement;
    }

    public void Execute()
    {
        if (_currentTime < _zero)
        {
            randomDirection = new(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            _currentTime = _time;
        }

        _movement.Move(randomDirection, _movement.MoveSpeed);

        _currentTime -= Time.fixedDeltaTime;
    }
}
