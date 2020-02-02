using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private bool opening = false;
    private bool closing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            transform.position += new Vector3(0, .2f, 0) * Time.deltaTime;
        }
    }

    public void openDoor()
    {
        if (opening == false && closing == false)
        {
            opening = true;
        }
    }
}
