using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    public bool playerIsOverlapping = false;

    void Update()
    {

        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            Debug.Log(dotProduct);

            if (dotProduct > 0)
            {
                float rotationDifference = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDifference += 180;
                player.Rotate(Vector3.up, rotationDifference);

                Vector3 positionOffset = Quaternion.Euler(0, rotationDifference, 0) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                playerIsOverlapping = false;
                Debug.Log("should have moved");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            Debug.Log("This should fire");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
