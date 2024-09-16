using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController playerController;
    Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void Start()
    {
        target = playerController.transform;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
