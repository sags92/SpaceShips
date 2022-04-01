using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartMission()
    {
        SceneManager.LoadScene("MainGame");
    }
}