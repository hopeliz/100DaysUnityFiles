using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public GameObject colliderObjectInRoom;
    public GameObject otherCollider;

    public bool playerIsOverlapping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (playerIsOverlapping)
        {
            colliderObjectInRoom.GetComponent<PortalTeleporter>().enabled = true;
            otherCollider.GetComponent<PortalTeleporter>().enabled = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            Debug.Log("This should water");
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
