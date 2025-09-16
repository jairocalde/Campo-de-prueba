using Unity.VisualScripting;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    [SerializeField] float sensitivityX = 8f; //To control the mouse sensitivity in X
    [SerializeField] float sensitivityY = 0.5f; //To control the mouse sensitivity in Y
    float mouseX, mouseY; //to store the final mouse input

    [SerializeField] Transform playerCamera;//To connect the Camera
    [SerializeField] float xClamp = 85f;//To limit rotation up and down
    float xRotation = 0f;


    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime); //Rotate player in Y using the mouse movement in X
        xRotation -= mouseY; //we use "-" because "+" give the opposite direction
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);//Limit the rotation between -xClamp and xClamp
        Vector3 targetRotation = transform.eulerAngles;//Saves the rotation of the object in eulerAngles.
        
        //remember that unity stores rotations as Quaternions internally.
        targetRotation.x = xRotation;//saves de xRotation into the X component of "targetRotation"
        playerCamera.eulerAngles = targetRotation;//applies the targetRotation to the player camera retaining the X and Z existing rotations

    }

    public void ReceiveInput(Vector2 mouseInput) //method to receive the mouse input
    {
        mouseX = mouseInput.x * sensitivityX; //mouse input in X
        mouseY = mouseInput.y * sensitivityY; //mouse input in Y
    }
}
