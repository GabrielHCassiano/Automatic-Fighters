using UnityEngine;

public class CombatControl : MonoBehaviour
{

    private InputsControl inputsControl;

    private StatusControl statusControl;

    public CombatControl(InputsControl inputsControl, StatusControl statusControl)
    {
        this.inputsControl = inputsControl;
        this.statusControl = statusControl;
    }

    public void AttackLogic()
    {
        if (statusControl.Can_Attack && inputsControl.LowInput)
        {
            inputsControl.LowInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Low = true;
        }

        if (statusControl.Can_Attack && inputsControl.MediumInput)
        {
            inputsControl.MediumInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Medium = true;
        }

        if (statusControl.Can_Attack && inputsControl.HeavyInput)
        {
            inputsControl.HeavyInput = false;
            statusControl.Can_Attack = false;
            statusControl.Can_Move = false;
            statusControl.Can_Dash = false;
            statusControl.In_Heavy = true;
        }
    }
}
