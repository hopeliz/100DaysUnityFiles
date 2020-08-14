using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWithProximity : MonoBehaviour
{
    public GameObject anim;
    public int distanceToAnimation;
    public List<Material> horse;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distanceToAnimation = Mathf.Abs(Mathf.FloorToInt(transform.position.z - anim.transform.position.z) + 1);

        if (distanceToAnimation > 0 && distanceToAnimation < 11)
        {
            anim.GetComponent<Renderer>().material = horse[distanceToAnimation];
            print(distanceToAnimation);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }
        
        
    }
}
