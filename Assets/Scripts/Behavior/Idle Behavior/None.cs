using UnityEngine;

public class None : IBehavior
{

    public void Execute()
    {
        Debug.Log("Я стою афк, меня не трогать!");
    }
}
