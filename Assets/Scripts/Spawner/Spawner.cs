using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private IdleBehaviorTypes _idleBehaviorTypes;
    [SerializeField] private ReactionBehaviorTypes _reactionBehaviorTipes;

    [SerializeField] private List<Transform> _patrolPoints;

    private Enemy _enemy;
    private Movement _movement;
    private EnemyDetector _enemyDetector;
    private IBehavior _idleBehavior;
    private IBehavior _reactionBehavior;


    private void Start()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint);
        _movement = _enemy.GetComponent<Movement>();
        _enemyDetector= _enemy.GetComponentInChildren<EnemyDetector>();

        StateIdle(_idleBehaviorTypes);
        StateReaction(_reactionBehaviorTipes);

        _enemy.Init(_idleBehavior, _reactionBehavior);

        _enemy.transform.parent = null;
    }

    public void StateIdle(IdleBehaviorTypes idleBehaviorTypes)
    {
        switch (idleBehaviorTypes)
        {
            case IdleBehaviorTypes.None:
                _idleBehavior = new None();
                break;
            case IdleBehaviorTypes.Patrol:
                _idleBehavior = new Patrol(_enemy.transform, _movement, _patrolPoints);
                break;
            case IdleBehaviorTypes.RandomWalk:
                _idleBehavior = new RandomWalk(_movement);
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
                _reactionBehavior = new Flee(_enemyDetector, _movement);
                break;
            case ReactionBehaviorTypes.Chase:
                _reactionBehavior = new Chase(_enemyDetector, _movement);
                break;
            case ReactionBehaviorTypes.Scare:
                _reactionBehavior = new Scare(_enemy);
                break;
            default:
                Debug.Log("Такое состояние не поддерживается!");
                break;
        }
    }
}
