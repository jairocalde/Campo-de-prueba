using UnityEngine;

public class InputManager : MonoBehaviour 
{
    [SerializeField] Movement movement;

    [SerializeField] MouseLook mouseLook; // to reference the MouseLook script

    PlayerControls controls; //Variable. Instance of playercontrol to handle player inputs
    PlayerControls.GroundMovementActions groundMovement;
    Vector2 horizontalInput;

    Vector2 mouseInput; // to store the input from the mouse

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        //Read the jump event, using a discartable var. x to execute function OnJumpPressed() on "movement" script.
        groundMovement.Jump.performed += x => movement.OnJumpPressed();

        //when MouseX and MouseY actions are performed = call functions to store the values
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);// pass "mouseInput" to "ReceiveInput()" method on "mouseLook" script
    }
    private void OnEnable()
    {
        controls.Enable ();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}
