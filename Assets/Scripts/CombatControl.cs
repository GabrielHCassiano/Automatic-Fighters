using UnityEngine;
using UnityEngine.InputSystem;

public class CombatControl : MonoBehaviour
{

    private InputsControl inputsControl;

    private StatusControl statusControl;

    private string inputAction = "";

    public CombatControl(InputsControl inputsControl, StatusControl statusControl)
    {
        this.inputsControl = inputsControl;
        this.statusControl = statusControl;
    }

    public void AttackLogic()
    {

        if (inputsControl.State_MotionAction == "Attack Low")
        {
            inputsControl.State_MotionAction = "";
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Low = true;
        }
        if (inputsControl.State_MotionAction == "Attack Medium")
        {
            inputsControl.State_MotionAction = "";
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Medium = true;
        }
        if (inputsControl.State_MotionAction == "Attack Heavy")
        {
            inputsControl.State_MotionAction = "";
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Heavy = true;
        }

        /*if (statusControl.Can_Attack && inputsControl.Current_InputAction == "low" && inputAction != "low")
        {
            inputAction = "low";
            //inputsControl.LowInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Low = true;
        }

        if (statusControl.Can_Attack && inputsControl.Current_InputAction == "medium" && inputAction != "medium")
        {
            inputAction = "medium";
            //inputsControl.MediumInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Medium = true;
        }

        if (statusControl.Can_Attack && inputsControl.Current_InputAction == "heavy" && inputAction != "heavy")
        {
            inputAction = "heavy";
            //inputsControl.HeavyInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Heavy = true;
        }

        if (statusControl.Can_Attack && inputsControl.Current_InputAction == "" && inputAction != "")
        {
            inputAction = "";
        }*/
    }
}
