using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            rightDoor.transform.position = Vector3.forward * .25f;
            leftDoor.transform.position = Vector3.forward * -.25f;
        }
    }
}
