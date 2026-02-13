using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HorizontalAxie = "Horizontal";
    private const string VerticalAxie = "Vertical";

    private Movement _movement;
    private Vector3 _direction;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        _direction = new Vector3(Input.GetAxis(HorizontalAxie), 0, Input.GetAxis(VerticalAxie));

        _movement.Move(_direction, _movement.MoveSpeed);
        _movement.Rotate(_direction, _movement.RotateSpeed);
    }
}
