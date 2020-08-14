using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowY : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.up * speed * Time.deltaTime;
    }
}
