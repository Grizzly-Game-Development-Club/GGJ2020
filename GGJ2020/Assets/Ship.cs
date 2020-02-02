using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int hull;
    public int oxy;
    public int power;

    //maybe add msgs here 
    // Start is called before the first frame update
    void Start()
    {
        hull = 1000;
        oxy = 100;
        power = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
