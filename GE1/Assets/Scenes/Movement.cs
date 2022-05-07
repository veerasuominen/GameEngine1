using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    //public Transform cam;
    public float speed =5f;
    float InputX;
    float InputZ;
    Vector3 movement;
    Vector3 velocity;
    float gravity =0.5f;
    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");
       InputZ = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        movement = controller.transform.forward * InputZ;
        controller.transform.Rotate(Vector3.up * InputX * (100f * Time.deltaTime));
        controller.Move(movement * speed * Time.deltaTime);
        controller.Move(velocity);
    }
}
