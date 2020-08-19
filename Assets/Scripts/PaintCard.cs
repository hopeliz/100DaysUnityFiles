using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCard : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform parentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            GameObject paintCard = Instantiate(cardPrefab.gameObject, new Vector3(transform.position.x, transform.position.y - 0.01F, transform.position.z), transform.rotation, parentObject);
        }
    }
}
