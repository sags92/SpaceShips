using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject ingameUI;
    private AsteroidGenerator asteroidGenerator;
    private UI_TotalScore totalScore;
    public bool isGameOver;

    private void Awake()
    {
        asteroidGenerator = FindObjectOfType<AsteroidGenerator>();
        totalScore = FindObjectOfType<UI_TotalScore>();
    }

    public void ShowGameOverUI()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        ingameUI.SetActive(false);
    }

    public void ResetScore()
    {
        GlobalSettings.ResetTotalDestroyed();
    }

    public void UnsubscribeEvents()
    {
        asteroidGenerator.UnsubscribeOnGameOver();
        totalScore.UnSubscribeOnGameOver();
    }
}