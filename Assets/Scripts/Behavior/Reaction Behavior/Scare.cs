using UnityEngine;

public class Scare : IBehavior
{
    private readonly Enemy _enemy;

    public Scare(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Вхожу в состояние - Scare");
    }

    public void Execute()
    {
        Debug.Log("< Умер от испуга >");
        _enemy.Die();
    }

    public void Exit()
    {
        Debug.Log("Выхожу из состояния - Scare");
    }
}
