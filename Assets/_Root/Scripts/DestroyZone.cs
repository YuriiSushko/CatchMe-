using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FallingObject>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}