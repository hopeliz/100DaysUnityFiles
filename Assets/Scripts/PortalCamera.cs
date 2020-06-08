using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform nearestPortal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - nearestPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, nearestPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        
    }
}
