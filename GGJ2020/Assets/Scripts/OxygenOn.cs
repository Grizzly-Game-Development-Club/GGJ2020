using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenOn : MonoBehaviour
{
    public bool gravityOn = false;
    GameObject player;
    [SerializeField] private OxygenReplinesh oxygenReplinesh;
    [SerializeField] private OxygenReduce oxygenReduce;
    public float tank = .1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gravityOn == false)
            {
                gravityOn = true;
            }
            else
            {
                gravityOn = false;
            }
        }
    }
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (gravityOn == true)
        {
            oxygenReduce.Reduce(tank);
        }
        else
        {
            oxygenReplinesh.Replinesh(tank);
        }
    }
}