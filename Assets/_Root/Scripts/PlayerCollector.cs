using UnityEngine;

namespace Assets._Root.Scripts
{
    public class PlayerCollector : MonoBehaviour
    {
        [SerializeField]
        private GameController GameController;

        [SerializeField]
        private PlayerVisuals playerVisuals;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            FallingObject fallingObject = collision.GetComponent<FallingObject>();

            if (fallingObject == null)
            {
                return;
            }

            GameController.AddScore(fallingObject.ScoreValue);
            playerVisuals.PlayHitEffect();

            Destroy(collision.gameObject);
        }
    }
}
