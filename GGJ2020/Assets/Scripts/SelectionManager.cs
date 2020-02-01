﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private GameObject holding = null;

    public GameObject itemHammer;

    private Transform _selection;

    void Update()
    {
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
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;

                //If the character is holding nothing, you may pick up an item.
                if (holding == null)
                {
                    //On Left Click
                    if (Input.GetMouseButtonDown(0))
                    {
                        holding = GameObject.Find(selection.name);

                        //Find item and if name
                        if (holding.name == "Hammer")
                        {
                            itemHammer.GetComponent<Renderer>().enabled = true;
                        }
                        else
                        {

                        }

                        //Hide World Item Model
                        holding.GetComponent<Renderer>().enabled = false;
                        holding.GetComponent<Collider>().enabled = false;
                    }
                }
            }
        }

        if (holding != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (holding.name == "Hammer")
                {
                    itemHammer.GetComponent<Renderer>().enabled = false;
                    holding.transform.position = (new Vector3(GameObject.Find("ToolHammer").transform.position.x, GameObject.Find("ToolHammer").transform.position.y, GameObject.Find("ToolHammer").transform.position.z));
                    holding.transform.rotation = Quaternion.Euler(GameObject.Find("ToolHammer").transform.rotation.x, GameObject.Find("ToolHammer").transform.rotation.y, GameObject.Find("ToolHammer").transform.rotation.z);
                }
                else
                {

                }
                holding.GetComponent<Renderer>().enabled = true;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<Rigidbody>().AddForce(new Vector3(0, 25, 0));
                holding.GetComponent<Rigidbody>().AddForce(transform.forward * 50);

                holding = null;
            }
        }
    }
}
