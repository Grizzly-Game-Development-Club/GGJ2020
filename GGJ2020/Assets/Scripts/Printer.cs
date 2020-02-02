using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject itemHammer;
    public GameObject itemScrewdriver;
    public GameObject itemWrench;
    public GameObject itemWireKit;
    public GameObject itemFireExtinguisher;

    private GameObject printedItem = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

    }

    public void StartPrint()
    {
        if (printedItem == null)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                printedItem = (GameObject)Instantiate(itemHammer, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                printedItem = (GameObject)Instantiate(itemScrewdriver, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                printedItem = (GameObject)Instantiate(itemWrench, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                printedItem = (GameObject)Instantiate(itemWireKit, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                printedItem = (GameObject)Instantiate(itemFireExtinguisher, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
            }
            printedItem.tag = "Printed";
            //Had to do cause it was not saving properly
            printedItem = GameObject.FindGameObjectWithTag("Printed");
        }
    }

    public void FinishPrint()
    {
        printedItem.tag = "Selectable";
        printedItem = null;
    }
}
