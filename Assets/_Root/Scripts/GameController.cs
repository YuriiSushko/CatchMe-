using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject gameEndText;

    [SerializeField]
    private GameObject slowPowerUpIcon;

    [SerializeField]
    private float speedMultiplier = 1f;

    private float slowTimer = 0f;
    public float SpeedMultiplier => speedMultiplier;

    private void Start()
    {
        Time.timeScale = 1f;
        UpdateScoreUI();
    }

    void Update()
    {
        if (slowTimer > 0f)
        {
            slowTimer -= Time.unscaledDeltaTime;

            if (slowTimer <= 0f)
            {
                speedMultiplier = 1f;
                if (slowPowerUpIcon != null)
                {
                    slowPowerUpIcon.SetActive(false);
                }
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score < 0)
        {
            score = 0;
            GameOver();
            return;
        }

        UpdateScoreUI();
    }

    public void ActivateSlow(float duration, float slowAmount)
    {
        speedMultiplier = slowAmount;
        slowTimer = duration;
        if (slowPowerUpIcon != null)
        {
            slowPowerUpIcon.SetActive(true);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        if (scoreText != null)
        {
            gameEndText.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
