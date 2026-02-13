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

    public void Enter()
    {
        Debug.Log("Вхожу в состояние - Scare");
    }

    public void Execute()
    {
        Debug.Log("< Умер от испуга >");
        Die();
    }

    public void Exit()
    {
        Debug.Log("Выхожу из состояния - Scare");
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
