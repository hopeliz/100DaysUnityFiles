using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject redLight1;
    public GameObject redLight2;
    public GameObject lightGroup1;
    public GameObject lightGroup2;
    public GameObject door;
    public Vector3 doorClosedLocation;
    public Vector3 doorOpenLocation;

    public float delayTime;
    public float delaySpeed;
    public float delayCountdown;
    public float doorSpeed;
    public float flashTime;
    public float flashSpeed;
    public float flashCountdown;

    public bool redLightOn = false;
    public bool doorOpen = false;
    public bool doorMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        flashCountdown = flashTime;
        delayCountdown = delayTime;
        if (!doorOpen)
        {
            doorClosedLocation = door.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (redLightOn)
        {
            flashCountdown -= Time.deltaTime * flashSpeed;

            if (flashCountdown <= 0)
            {
                redLightOn = false;
                redLight1.SetActive(false);
                redLight2.SetActive(false);
                flashCountdown = flashTime;
            }
        }
        else
        {
            flashCountdown -= Time.deltaTime * flashSpeed;

            if (flashCountdown < 0)
            {
                redLightOn = true;
                redLight1.SetActive(true);
                redLight2.SetActive(true);
                flashCountdown = flashTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            doorMoving = true;
        }

        if (doorMoving)
        {
            door.transform.position += Vector3.up * Time.deltaTime * doorSpeed;

            if (door.transform.position.y >= doorOpenLocation.y)
            {
                doorMoving = false;
                doorOpen = true;
            }
        }

        if (doorOpen)
        {
            if (!lightGroup1.activeSelf || !lightGroup2.activeSelf)
            {
                delayCountdown -= Time.deltaTime * delaySpeed;

                if (delayCountdown < 0 && !lightGroup1.activeSelf)
                {
                    lightGroup1.SetActive(true);
                    delayCountdown = delayTime;
                }

                if (delayCountdown < 0 && lightGroup1.activeSelf)
                {
                    lightGroup2.SetActive(true);
                }
            } 
        }
    }
}
