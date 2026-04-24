using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed = 3f;

    [SerializeField]
    private int scoreValue = 1;

    [SerializeField]
    private bool isSlowPowerUp = false;

    private GameController controller;

    public bool IsSlowPowerUp => isSlowPowerUp;

    private void Start()
    {
        controller = FindFirstObjectByType<GameController>();
    }

    private void Update()
    {
        float speedMultiplier = controller != null ? controller.SpeedMultiplier : 1f;

        transform.Translate(Vector2.down * fallSpeed * speedMultiplier * Time.deltaTime);
    }

    public int ScoreValue => scoreValue;
}