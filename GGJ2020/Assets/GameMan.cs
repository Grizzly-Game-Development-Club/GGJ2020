using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    GameObject[] interatables;
    GameObject myShip;
    float time = 300f;
    float lastT = 300f;
    // Start is called before the first frame update
    void Start()
    {
        if(interatables == null)
        {
            interatables = GameObject.FindGameObjectsWithTag("Interactable");
        }

        if (myShip == null)
        {
            myShip = GameObject.Find("Ship");
        }

        Debug.Log("welcome to the Spaceship Repair!");

    }

    // Update is called once per frame
    void Update()
    {
        //Trying to rpair
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Interactable"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("We Got here!");
                    if (gameObject.GetComponent<SelectionManager>().holding != null)
                    {
                        GameObject.Find(selection.name).GetComponent<Interactable>().repair(gameObject.GetComponent<SelectionManager>().holding.name);

                    }
                }
            }
        }
                //timer
                timer();
                if (time < lastT)
                {
                    randDamage(time);
                    lastT = time - 1;
                }
                msgSystem();
            }

            void timer()
            {
                time = time - Time.deltaTime;
                if (time % 60 == 0)
                {
                    Debug.Log("Time Remaining: " + (Mathf.Round(time / 60) - 1) + ":" + Mathf.Round(time % 60));
                }
                if (time <= 0)
                {
                    GameObject.Find("Player").GetComponent<CharacterController>().enabled = false;
                    Time.timeScale = 0;
                    Debug.Log("You Win!");
                }
            }

            void randDamage(float time)
            {
                //Debug.Log("hey!");
                int chance = 0;
                int val = Random.Range(0, 100);
                if (time > 200)
                {
                    //5%
                    chance = 5;
                    //Debug.Log("hi");
                } else if (time > 100)
                {
                    //10%
                    chance = 10;
                    //Debug.Log("HI2");
                }
                else
                {

                    //15%
                    chance = 15;
                }

                if (val < chance)
                {
                    GameObject takeDam = interatables[Random.Range(0, interatables.Length)];
                    string str = takeDam.name;
                    takeDam.GetComponent<Interactable>().deviceHealth -= 10;
                    takeDam.GetComponent<Interactable>().isDam = true;
                    //Debug.Log(str + " is being damaged");
                    //Debug.Log("chance is " + chance);


                }

            }
            void msgSystem()
            {
                //system health msg
                string msg = "Ship Hull: " + myShip.GetComponent<Ship>().hull + "\n";
                foreach (GameObject system in interatables)
                {
                    msg = msg + system.name + ": " + system.GetComponent<Interactable>().deviceHealth + "\n";
                }

                //Debug.Log(msg);
                //time message

                //alert mssg

            }
        }
 
