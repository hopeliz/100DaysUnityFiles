using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintLines : MonoBehaviour
{
    public GameObject prefabPaint;
    public Material paintMaterial;

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
            print(other);
            GameObject paintBlock = Instantiate(prefabPaint, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01F), transform.rotation);
            paintBlock.GetComponent<Renderer>().material = paintMaterial;
        }
    }
}
