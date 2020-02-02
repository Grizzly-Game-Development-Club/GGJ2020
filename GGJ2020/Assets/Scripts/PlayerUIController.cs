using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    //operating the helmet 'overlay', maybe game timer?
    MeshRenderer helmetRend;

    // Start is called before the first frame update
    void Start()
    {
        helmetRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //operating on h button press, can change to interactable trigger
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(KeyCode.H);
            if (helmetRend.enabled)
            {
                helmetRend.enabled = false;
                Debug.Log("Helmet off");
            }
            else
            {
                helmetRend.enabled = true;
                Debug.Log("Helmet on");
            }
        }
    }
}
