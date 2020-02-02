using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{

    public bool engineDamaged = false;
    public bool oxygenDamaged = false;
    private ArrayList engineRepairs = new ArrayList();
    private ArrayList oxygenRepairs = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        //ArrayList engineRepairs = new ArrayList();
        engineRepairs.Add("Screwdriver");
        engineRepairs.Add("Wrench");
        engineRepairs.Add("Wire Kit");
        engineRepairs.Add("Fire Extinguisher");

        oxygenRepairs.Add("Screwdriver");
        oxygenRepairs.Add("Wrench");
        oxygenRepairs.Add("Hammer");
        oxygenRepairs.Add("Fire Extinguisher");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Repair(string holding, string target)
    {
        if (target == "Engine")
        {
            if (engineRepairs.Contains(holding))
            {
                engineDamaged = false;
            }
            else
            {
                Debug.Log("Tool is not supported!");
            }
        }
        else if (target == "Oxygen Generator")
        {
            if (oxygenRepairs.Contains(holding))
            {
                oxygenDamaged = false;
            }
            else
            {
                Debug.Log("Tool is not supported!");
            }
        }
    }
}
