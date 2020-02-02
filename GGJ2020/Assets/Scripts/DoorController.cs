using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private bool opening = false;
    private bool closing = false;
    private bool waiting = false;

    private float doorSpeed = 1;
    private int count = 0;

    void Update()
    {
        if (opening) {
            if (count <= 200)
            {
                count++;
                transform.position += new Vector3(0, doorSpeed, 0) * Time.deltaTime;
            }
            else
            {
                count = 0;
                opening = false;
                waiting = true;
            }
        }
        else if (waiting)
        {
            if (count <= 100) {count++;} else
            {
                count = 0;
                closing = true;
                waiting = false;
            }
        }
        else if (closing)
        {
            if (count <= 200)
            {
                count++;
                transform.position += new Vector3(0, doorSpeed * -1, 0) * Time.deltaTime;
            }
            else
            {
                count = 0;
                closing = false;
            }
        }
    }

    public void openDoor()
    {
        if (opening == false && closing == false && waiting == false)
        {
            opening = true;
        }
    }
}
