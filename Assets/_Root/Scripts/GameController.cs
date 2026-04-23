using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        Time.timeScale = 1f;
        UpdateScoreUI();
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

        Time.timeScale = 0f;
    }
}
