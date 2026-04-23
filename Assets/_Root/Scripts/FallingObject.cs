using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController gameController = FindFirstObjectByType<GameController>();

            if (gameController != null)
            {
                gameController.AddScore(scoreValue);
            }

            Destroy(gameObject);
        }
    }
}

