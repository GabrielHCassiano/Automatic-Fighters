using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    private InputsControl inputsControl;
    private Rigidbody2D rb;

    private StatusControl statusControl;

    public MoveControl (InputsControl inputsControl, Rigidbody2D rb, StatusControl statusControl)
    {
        this.inputsControl = inputsControl;
        this.rb = rb;
        this.statusControl = statusControl;
    }

    public void MovementeLogic()
    {
        /*if (statusControl.Can_Move)
        {
            rb.linearVelocity = new Vector2(inputsControl.DirectionInput.x * statusControl.Speed_Move, rb.linearVelocity.y);
        }*/

        if (inputsControl.State_MotionAction == "Move Back")
        {
            rb.linearVelocity = new Vector2(-1 * statusControl.Speed_Move, rb.linearVelocity.y);
        }
        else if (inputsControl.State_MotionAction == "Move Front")
        {
            rb.linearVelocity = new Vector2(1 * statusControl.Speed_Move, rb.linearVelocity.y);
        }
    }

    public void DashLogic()
    {
        /*if (statusControl.Can_Dash && inputsControl.ShadowInput && inputsControl.DirectionInput.x != 0)
        {
            inputsControl.ShadowInput = false;
            statusControl.StartCoroutine(statusControl.CooldownDash(rb, inputsControl.DirectionInput.x));
        }*/

        if (inputsControl.State_MotionAction == "Back Dash")
        {
            statusControl.StartCoroutine(statusControl.CooldownDash(rb, -1));
        }
        else if (inputsControl.State_MotionAction == "Front Dash")
        {
            statusControl.StartCoroutine(statusControl.CooldownDash(rb, 1));
        }
    }

    public void JumpLogic()
    {

    }

}
