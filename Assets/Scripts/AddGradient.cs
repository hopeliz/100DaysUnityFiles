using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGradient : MonoBehaviour
{
    [Range(0.1F, 10)]
    public float tiling = 1;
    [Range(-5.0F, 5.0F)]
    public float offset = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(0, tiling);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);

    }
}
