using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private IdleBehaviorTypes _idleBehaviorTypes;
    [SerializeField] private ReactionBehaviorTypes _reactionBehaviorTipes;

    [SerializeField] private List<Transform> _patrolPoints;

    private void Start()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint);

        enemy.SetIdleState(_idleBehaviorTypes);
        enemy.SetReactionState(_reactionBehaviorTipes);

        if (_idleBehaviorTypes == IdleBehaviorTypes.Patrol)
            enemy.SetPatrolPoint(_patrolPoints);

        enemy.transform.parent = null;
    }
}
