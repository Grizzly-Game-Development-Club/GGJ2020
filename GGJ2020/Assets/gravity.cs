using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public bool gravityOn = true;
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");

        if (other.tag == "player")
        {
            gravityOn = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityOn == false)
        {
           playerMovement move = player.GetComponent<playerMovement>();
            // gravity.player = 0;
            move.GravityEnabled;
        }
    }
}
