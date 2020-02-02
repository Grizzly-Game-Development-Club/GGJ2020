using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform gravityCheck;
    public float gravityDistance = 0.4f;
    public LayerMask gravityMask;

    public bool gravityEnabled = true;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        if (gravityEnabled)
        {
            isGrounded = Physics.CheckSphere(gravityCheck.position, gravityDistance, gravityMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movePlayer = transform.right * x + transform.forward * z;

        if (gravityEnabled)
        {
            controller.Move(movePlayer * speed * Time.deltaTime);
        }
        else
        {
            controller.Move((movePlayer * speed * Time.deltaTime)/3);
        }

        if (gravityEnabled)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (gravityEnabled == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                controller.Move((transform.up * speed * Time.deltaTime)/3);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                controller.Move(((transform.up * speed * Time.deltaTime) / 3) * -1);
            }
        }

        if (Input.GetKey("x"))
        {
            gravityEnabled = false;
        }
    }
}
