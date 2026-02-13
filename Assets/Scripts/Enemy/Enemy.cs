using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDetector _detector;
    [SerializeField] private ParticleSystem _deathEffect;

    private IBehavior _idleBehavior;
    private IBehavior _reactionBehavior;

    public void Update()
    {
        if (_detector.Target != null)
            _reactionBehavior.Execute();
        else
            _idleBehavior.Execute();
    }

    public void Init(IBehavior idleBehavior, IBehavior reactionBehavior)
    {
        _idleBehavior = idleBehavior;
        _reactionBehavior = reactionBehavior;
    }

    public void Die()
    {
        _deathEffect.Play();
        _deathEffect.transform.parent = null;

        Destroy(gameObject);
    }
}
