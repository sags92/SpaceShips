using UnityEngine;

public class CameraInfo : MonoBehaviour
{
    public float width;
    public float height;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        height = mainCamera.orthographicSize * 2;
        width = mainCamera.aspect * height;
    }
}