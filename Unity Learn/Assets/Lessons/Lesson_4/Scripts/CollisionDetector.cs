using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }
}
