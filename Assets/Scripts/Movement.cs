using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _minMoveDistance = 0.01f;

    public void Move(Vector3 direction, float speed)
    {
        Vector3 step = direction.normalized * speed * Time.fixedDeltaTime;
        transform.Translate(step, Space.World);
    }

    public void Rotate(Vector3 direction, float speed)
    {
        if (direction.magnitude > _minMoveDistance)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = speed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}
