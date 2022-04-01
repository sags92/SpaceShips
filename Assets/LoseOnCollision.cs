using UnityEngine;

public class LoseOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject ingameUI;

    private void OnCollisionEnter2D(Collision2D collidingObj)
    {
        if (collidingObj.gameObject.GetComponent<Asteroid>() == null)
            return;
        Lose();
    }

    private void Lose()
    {
        gameOverScreen.SetActive(true);
        ingameUI.SetActive(false);
    }
}