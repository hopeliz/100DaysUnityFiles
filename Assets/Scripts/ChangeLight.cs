using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public Material redLight;
    public Material red;

    public bool redLightOn = false;
    public float redCountdown;
    public float redLength = 2;

    // Start is called before the first frame update
    void Start()
    {
        redCountdown = redLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (redLightOn)
        {
            redCountdown -= Time.deltaTime;

            if (redCountdown <= 0)
            {
                GetComponent<Renderer>().material = red;
                redLightOn = false;
                redCountdown = redLength;
            }
        }

        if (!redLightOn)
        {
            redCountdown -= Time.deltaTime;

            if (redCountdown <= 0)
            {
                GetComponent<Renderer>().material = redLight;
                redLightOn = true;
                redCountdown = redLength;
            }
        }

        
    }
}
