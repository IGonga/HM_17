using UnityEngine;

public class Scare : IBehavior
{
    private readonly Enemy _enemy;
    private readonly ParticleSystem _deathEffect;

    public Scare(Enemy enemy, ParticleSystem deathEffect)
    {
        _enemy = enemy;
        _deathEffect = deathEffect;
    }

    public void Execute()
    {
        Debug.Log("< ”мер от испуга >");
        Die();
    }

    public void Die()
    {
        if (_deathEffect == null)
            return;

        _deathEffect.Play();
        _deathEffect.transform.parent = null;

        Object.Destroy(_enemy.gameObject);
    }
}
