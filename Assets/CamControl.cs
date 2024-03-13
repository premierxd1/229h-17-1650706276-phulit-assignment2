using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset = new Vector3(0f, 2f, -5f); // The offset from the target object

    public float smoothSpeed = 0.125f; // The speed at which the camera follows the target

    void FixedUpdate()
    {
        // Calculate the desired position based on the target's position and rotation
        Vector3 desiredPosition = target.position - target.forward * offset.z + target.up * offset.y;
        
        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Look at the target
        transform.LookAt(target);
    }
}
