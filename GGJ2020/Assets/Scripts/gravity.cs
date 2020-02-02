using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public bool gravityOn = true;
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gravityOn)
            {
                gravityOn = false;
            } else
            {
                gravityOn = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityOn == false)
        {
           PlayerMovement move = player.GetComponent<PlayerMovement>();
            // gravity.player = 0;
            move.gravityEnabled = false;
        }
    }
}
