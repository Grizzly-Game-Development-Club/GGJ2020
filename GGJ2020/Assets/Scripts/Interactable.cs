using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float elapsed;
    public bool isDam;
    public int deviceHealth = 100;
    public string[] aloudTools;
    // Start is called before the first frame update
    void Start()
    {
        elapsed = 0f;
        aloudTools  = new string[2];
        GameObject[] allTools = GameObject.FindGameObjectsWithTag("Selectable");
        int ran = Random.Range(0, allTools.Length-1);
        int ran2;
        do
        {
            ran2 = Random.Range(0, allTools.Length-1);
        } while (ran2 == ran);
        string str = allTools[ran].name;
        string st2 = allTools[ran2].name;
        
        
        aloudTools[0] = str;
        aloudTools[1] = st2;

        //Debug.Log("Hi I am " + name + " I can be fixed by " + aloudTools[0] + " and " + aloudTools[1]);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 2f)
        {
            if (isDam)
            {
                deviceHealth -= 1;
                if (deviceHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
            elapsed = 0; 
        }
    }
    public void repair(string hold)
    {
        if (hold.Contains(aloudTools[0])||hold.Contains(aloudTools[1]))
        {
            isDam = false;
            deviceHealth += 1;
        }
        else
        {
            Debug.Log("Hi I am " + name + " I can be fixed by " + aloudTools[0] + " and " + aloudTools[1]);
        }
        Debug.Log("Trying to repair!");
    }
}
