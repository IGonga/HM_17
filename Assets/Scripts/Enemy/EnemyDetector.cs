using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public Transform Target { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Target = player.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Target = null;
        }
    }
}
