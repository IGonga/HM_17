using UnityEngine;

public class None : IBehavior
{
    public void Enter()
    {
        Debug.Log("Вхожу в состояние - None");
    }

    public void Execute()
    {
        Debug.Log("Я стою афк, меня не трогать!");
    }

    public void Exit()
    {
        Debug.Log("Выхожу из состояния - None");
    }
}
