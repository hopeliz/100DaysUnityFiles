using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWithPosition : MonoBehaviour
{
    public List<Material> horse;
    public List<float> location;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < horse.Count; i++)
        {
            if (i < 10)
            {
                if (transform.position.x >= location[i])
                {
                    GetComponent<Renderer>().material = horse[i];
                    print("i is " + i);
                }

                if (transform.position.x < location[0])
                {
                    transform.position = new Vector3(location[10], transform.position.y, transform.position.z);
                }
            }
            else
            {
                if (transform.position.x >= location[10])
                {
                    GetComponent<Renderer>().material = horse[10];
                }

                if (transform.position.x > location[10] + 1)
                {
                    transform.position = new Vector3(location[0], transform.position.y, transform.position.z);
                }
            }
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }

        
    }
}
