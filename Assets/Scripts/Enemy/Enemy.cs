using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    private float _moveSpeed = 4f;
    private float _rotateSpeed = 750f;

    private IdleBehaviorTypes _idleBehaviorType;
    private ReactionBehaviorTypes _reactionBehaviorType;
    private EnemyState _state;
    private Transform _target;
    private List<Transform> _patrolPoints;

    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotateSpeed;
    public Transform Target => _target;
    public Transform Transform => transform;
    public List<Transform> PatrolPoints => _patrolPoints;

    private void Awake()
    {
        _state = new EnemyState(this);
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            _state.StateIdle(_idleBehaviorType);
            return;
        }

        _state.StateReaction(_reactionBehaviorType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player target))
        {
            _target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player target))
        {
            _target = null;
        }
    }

    public void SetIdleState(IdleBehaviorTypes idleBehaviorType)
    {
        _idleBehaviorType = idleBehaviorType;
    }

    public void SetReactionState(ReactionBehaviorTypes reactionBehaviorType)
    {
        _reactionBehaviorType = reactionBehaviorType;
    }

    public void SetPatrolPoint(List<Transform> points)
    {
        _patrolPoints = points;
    }

    public void Die()
    {
        _deathEffect.Play();
        _deathEffect.transform.parent = null;

        Destroy(gameObject);
    }

    public Vector3 SetDirectionToPlayer()
    {
        if (_target == null)
        {
            Debug.Log("_target == null");
            return Vector3.zero;
        }

        Vector3 direction = _target.position - transform.position;

        return direction;
    }
}
