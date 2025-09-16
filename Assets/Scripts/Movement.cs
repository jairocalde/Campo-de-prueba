using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] CharacterController controller; // to reference CharacterController
    [SerializeField] float speed = 11f; //to set the speed

    [SerializeField] float gravity = -30f; //gravity value should be adjusted depending on the scale of the scene
    Vector3 verticalVelocity = Vector3.zero; //verticalVelocity vector inicialized in zero.
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    Vector2 horizontalInput;

    [SerializeField] float jumpHeight = 3.5f;//variable to set the jump height
    bool jump; //if it is jumping or not

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        if (isGrounded)
        {
            verticalVelocity.y = 0f; // reset the vertial position
        }

        //Calculates a velocity vector based on right dir
        //Calculates a velocity vector based on right dir. * x input from user + forward dir. * y input from user, and all of that * speed.
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;

        //Pass to the Move method on CharacterController the horizontalVelocity * deltatime (frame independant)
        controller.Move(horizontalVelocity * Time.deltaTime);

        // -- Do the jump BEFORE we update the gravity --
        if (jump) //if jump is on

            if (isGrounded) //if it is in the ground

                // Jump Formula: v = sqrt(-2 * jumpHeight * gravity)
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity); //do the jump and store it in "verticalVelocity.y"

        jump = false; //if it is NOT grounded


        verticalVelocity.y += gravity * Time.deltaTime; //calculate the vertical velocity + gravity * Time (frame independant)
        controller.Move(verticalVelocity * Time.deltaTime); //applies the verticalVelocity to the character controller. Time twice 'cause m/s^2

    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        print(horizontalInput);
    }

    //function to change the jump value from the InputManager script if the spacebar is pressed

    public void OnJumpPressed()
    { 
        jump = true; //turn on the jump
    }

}
