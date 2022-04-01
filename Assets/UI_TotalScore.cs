using TMPro;
using UnityEngine;

public class UI_TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;

    private void Awake()
    {
        Score.text = GlobalSettings.TotalDestroyed();
        EventManager.OnAsteroidShot += OnAsteroidShotHandler;
    }

    private void OnAsteroidShotHandler()
    {
        Score.text = GlobalSettings.TotalDestroyed();
    }

    public void UnSubscribeOnGameOver()
    {
        EventManager.OnAsteroidShot -= OnAsteroidShotHandler;
    }
}