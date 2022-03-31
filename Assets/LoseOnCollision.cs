using UnityEngine;

public class LoseOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject ingameUI;

    private void OnTriggerEnter2D(Collider2D CollidingObj)
    {
        if (CollidingObj.GetComponent<Asteroid>() == null)
            return;
        Lose();
    }

    private void Lose()
    {
        gameOverScreen.SetActive(true);
        ingameUI.SetActive(false);
    }
}