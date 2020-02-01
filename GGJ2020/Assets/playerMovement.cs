using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector3 rot;
    private Rigidbody rigid;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        Vector3 rotStep = Vector3.up * mx + Vector3.left * my;
        //get total rotation
        rot += rotStep * 360 * Time.deltaTime;
        //limit rotation around x
        rot.x = Mathf.Clamp(rot.x, -15, 15);
        //apply to camera
        transform.eulerAngles = rot;

        //Move Forwards
        if (Input.GetKey("w"))
        {
            rigid.velocity += new Vector3(0, 0, transform.forward.z);
            Mathf.Clamp(rigid.velocity.x, maxSpeed * -1, maxSpeed);
            Mathf.Clamp(rigid.velocity.y, maxSpeed * -1, maxSpeed);
            Mathf.Clamp(rigid.velocity.z, maxSpeed * -1, maxSpeed);
        }
        else if (Input.GetKeyUp("w"))
        {
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }

}
