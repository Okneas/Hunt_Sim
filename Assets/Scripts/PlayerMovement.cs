using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public static float stamina = 100f;
    Vector3 velocity;
    bool isGrounded;
    bool recovery = false, run = false;

   
    void Update()
    {

        if (stamina == 0.0f)
        {
            recovery = true;
        }
        if (stamina == 100.0f)
        {
            recovery = false;
        }
        if (run)
        {
            if (stamina >= 0f)
            {
                stamina -= 0.5f;
            }
        }
        if (!run)
        {
            if (stamina <= 100)
            {
                stamina += 0.5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!recovery)
            {
                run = true;
                speed = 10f;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = false;
            speed = 5f;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
