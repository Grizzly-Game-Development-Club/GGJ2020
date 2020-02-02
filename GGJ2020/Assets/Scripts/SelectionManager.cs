using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string interactableTag = "Interactable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private GameObject holding = null;

    public GameObject itemHammer;
    public GameObject itemFireExtinguisher;
    public GameObject itemScrewdriver;
    public GameObject itemWireKit;
    public GameObject itemWrench;

    private Transform _selection;

    public DeviceManager deviceManager;

    public Texture mekanik;
    public bool showMekanik;

    void Update()
    {
        //Change Material Back
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                //Change Material of Looking at Object
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                //Save Object, so we can change material back.
                _selection = selection;

                //If the character is holding nothing, you may pick up an item.
                if (holding == null)
                {
                    //On Left Click
                    if (Input.GetMouseButtonDown(0))
                    {
                        holding = GameObject.Find(selection.name);

                        //Find item and if name
                        if (holding.name.Contains("Hammer") && !holding.name.Contains("Tool"))
                        {
                            itemHammer.GetComponent<Renderer>().enabled = true;
                        }
                        else if (holding.name.Contains("Fire Extinguisher") && !holding.name.Contains("Tool"))
                        {
                            itemFireExtinguisher.GetComponent<Renderer>().enabled = true;
                        }
                        else if (holding.name.Contains("Screwdriver") && !holding.name.Contains("Tool"))
                        {
                            itemScrewdriver.GetComponent<Renderer>().enabled = true;
                        }
                        else if (holding.name.Contains("Wire Kit") && !holding.name.Contains("Tool"))
                        {
                            itemWireKit.GetComponent<Renderer>().enabled = true;
                        }
                        else if (holding.name.Contains("Wrench") && !holding.name.Contains("Tool"))
                        {
                            itemWrench.GetComponent<Renderer>().enabled = true;
                        }

                        //Hide World Item Model
                        holding.GetComponent<Renderer>().enabled = false;
                        holding.GetComponent<Collider>().enabled = false;
                    }
                }
            }
            else if (selection.CompareTag(interactableTag))
            {
                if (selection.name == "3D Printer")
                {
                    selection.GetComponent<Printer>().StartPrint();
                    if (Input.GetKey("b"))
                    {
                        selection.GetComponent<Printer>().FinishPrint();
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (holding != null)
                        {
                            deviceManager.Repair(holding.name, selection.name);
                        }
                        else
                        {
                            showMekanik = true;
                        }
                    }
                }
            }
        }

        if (holding != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (holding.name.Contains("Hammer") && !holding.name.Contains("Tool"))
                {
                    itemHammer.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolHammer").transform.position.x, GameObject.Find("ToolHammer").transform.position.y, GameObject.Find("ToolHammer").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolHammer").transform.rotation.x, GameObject.Find("ToolHammer").transform.rotation.y, GameObject.Find("ToolHammer").transform.rotation.z);
                }
                else if (holding.name.Contains("Fire Extinguisher") && !holding.name.Contains("Tool"))
                {
                    itemFireExtinguisher.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolFireExtinguisher").transform.position.x, GameObject.Find("ToolFireExtinguisher").transform.position.y, GameObject.Find("ToolFireExtinguisher").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolFireExtinguisher").transform.rotation.x, GameObject.Find("ToolFireExtinguisher").transform.rotation.y, GameObject.Find("ToolFireExtinguisher").transform.rotation.z);
                }
                else if (holding.name.Contains("Screwdriver") && !holding.name.Contains("Tool"))
                {
                    itemScrewdriver.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolScrewdriver").transform.position.x, GameObject.Find("ToolScrewdriver").transform.position.y, GameObject.Find("ToolScrewdriver").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolScrewdriver").transform.rotation.x, GameObject.Find("ToolScrewdriver").transform.rotation.y, GameObject.Find("ToolScrewdriver").transform.rotation.z);
                }
                else if (holding.name.Contains("Wire Kit") && !holding.name.Contains("Tool"))
                {
                    itemWireKit.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolWireKit").transform.position.x, GameObject.Find("ToolWireKit").transform.position.y, GameObject.Find("ToolWireKit").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolWireKit").transform.rotation.x, GameObject.Find("ToolWireKit").transform.rotation.y, GameObject.Find("ToolWireKit").transform.rotation.z);
                }
                else if (holding.name.Contains("Wrench") && !holding.name.Contains("Tool"))
                {
                    itemWrench.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolWrench").transform.position.x, GameObject.Find("ToolWrench").transform.position.y, GameObject.Find("ToolWrench").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolWrench").transform.rotation.x, GameObject.Find("ToolWrench").transform.rotation.y, GameObject.Find("ToolWrench").transform.rotation.z);
                }
                holding.GetComponent<Renderer>().enabled = true;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
                holding.GetComponent<Rigidbody>().AddForce(transform.forward * 80);

                holding = null;
            }
        }
    }

    private void OnGUI()
    {
        if (showMekanik)
        {
            GUI.DrawTexture(new Rect(100, 100, 500, 500), mekanik);
        }
    }
}
