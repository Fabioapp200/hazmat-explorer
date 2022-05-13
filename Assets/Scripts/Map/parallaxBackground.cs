using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 lastCameraPosition;

    public Vector2 parallaxEffectMultiplier;


    private void Start() {
    }

    private void LateUpdate() {
        
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

    }
}
