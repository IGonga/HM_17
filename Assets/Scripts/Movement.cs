using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotateSpeed = 750f;

    public float MoveSpeed => _moveSpeed;
    public float RotateSpeed => _rotateSpeed;

    private float _minMoveDistance = 0.01f;

    public void Move(Vector3 direction, float speed)
    {
        Vector3 step = direction.normalized * speed * Time.deltaTime;
        transform.Translate(step, Space.World);
    }

    public void Rotate(Vector3 direction, float speed)
    {
        if (direction.magnitude > _minMoveDistance)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}
