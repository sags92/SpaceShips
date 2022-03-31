using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    public float cameraBias;
    Vector3 cameraDisplacement = new Vector3(0, 0, 0);
    Vector3 newPosition = new Vector3();

    private void Awake()
    {
        cameraDisplacement.z = cameraBias;
    }

    private void LateUpdate()
    {
        newPosition = targetObject.transform.position + cameraDisplacement;
        transform.position = newPosition;
    }
}