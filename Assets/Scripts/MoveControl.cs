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
        if (statusControl.Can_Move)
        {
            rb.linearVelocity = new Vector2(inputsControl.DirectionInput.x * statusControl.Speed_Move, rb.linearVelocity.y);
        }
    }

    public void DashLogic()
    {
        if (statusControl.Can_Dash && inputsControl.ShadowInput && inputsControl.DirectionInput.x != 0)
        {
            inputsControl.ShadowInput = false;
            statusControl.StartCoroutine(statusControl.CooldownDash(rb, inputsControl.DirectionInput.x));
        }
    }

    public void JumpLogic()
    {

    }

}
