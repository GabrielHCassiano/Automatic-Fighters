using System.Collections;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.LookDev;
using UnityEngine.Rendering.UI;
using UnityEngine.U2D;

public class InputsControl : MonoBehaviour
{

    [SerializeField] private Vector2 directionInput;
    [SerializeField] private bool lowInput, mediumInput, heavyInput, shadowInput, powerInput, blockInput;

    [SerializeField] private bool canDirectionUpLeft, canDirectionUpRight, canDirectionDownLeft, canDirectionDownRight,
        canDirectionUp, canDirectionDown, canDirectionLeft, canDirectionRight,
        canRed, canGreen, canBlue, canCyan, canMagenta, canYellow, canBlackAndWhite, canPower, canBlock;

    private bool inMultipleInputs, inBlackAndWhite;

    private CurrentInputs currentInputs;
    private string current_InputMotion = "";
    private string sprite_InputMotion = "<sprite=13>";
    private string current_InputAction = "";
    private string sprite_InputAction = "";
    private int countInput = 0;

    private int current_State = 0;
    private string current_MotionAction;
    private string state_MotionAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentInputs = GetComponent<CurrentInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        //InputCurrent();
        //StateMotionAction();
    }

    private void FixedUpdate()
    {
        CurrentInputs();
        StateMotionAction();
    }

    private void LateUpdate()
    {
        //StateMotionAction();
    }

    public void CurrentInputs()
    {
        if (countInput <= 99)
        {
            currentInputs.InputCurrent[0] = sprite_InputMotion + sprite_InputAction + "\t\t" + countInput;

            countInput++;
        }

        CurrentInputsMotion();
        CurrentInputsAction();

    }

    public void CurrentInputsMotion()
    {
        if (directionInput.y > 0 && directionInput.x < 0 && current_InputMotion != "up_back")
        {
            SetCurrentInputsMotion("up_back", "<sprite=16>");
        }
        else if (directionInput.y > 0 && directionInput.x > 0 && current_InputMotion != "up_front")
        {
            SetCurrentInputsMotion("up_front", "<sprite=17>");
        }
        else if (directionInput.y < 0 && directionInput.x < 0 && current_InputMotion != "down_back")
        {
            SetCurrentInputsMotion("down_back", "<sprite=18>");
        }
        else if (directionInput.y < 0 && directionInput.x > 0 && current_InputMotion != "down_front")
        {
            SetCurrentInputsMotion("down_front", "<sprite=19>");
        }
        else if (directionInput.y > 0 && directionInput.x == 0 && current_InputMotion != "up")
        {
            SetCurrentInputsMotion("up", "<sprite=24>");
        }
        else if (directionInput.y < 0 && directionInput.x == 0 && current_InputMotion != "down")
        {
            SetCurrentInputsMotion("down", "<sprite=25>");
        }
        else if (directionInput.x < 0 && directionInput.y == 0 && current_InputMotion != "back")
        {
            SetCurrentInputsMotion("back", "<sprite=26>");
        }
        else if (directionInput.x > 0 && directionInput.y == 0 && current_InputMotion != "front")
        {
            SetCurrentInputsMotion("front", "<sprite=27>");
        }
        else if (directionInput.x == 0 && directionInput.y == 0 && current_InputMotion != "")
        {
            SetCurrentInputsMotion("", "<sprite=13>");
        }
    }

    public void CurrentInputsAction()
    {
        if (lowInput && mediumInput && heavyInput && current_InputAction != "black")
        {
            SetCurrentInputsAction("black", "<sprite=12");
        }
        else if (!lowInput && mediumInput && heavyInput && current_InputAction != "cyan")
        {
            SetCurrentInputsAction("cyan", "<sprite=6>");
        }
        else if (lowInput && !mediumInput && heavyInput && current_InputAction != "magenta")
        {
            SetCurrentInputsAction("magenta", "<sprite=8>");
        }
        else if (lowInput && mediumInput && !heavyInput && current_InputAction != "throw")
        {
            SetCurrentInputsAction("throw", "<sprite=10>");
        }
        else if (lowInput && !mediumInput && !heavyInput && current_InputAction != "low")
        {
            SetCurrentInputsAction("low", "<sprite=0>");
        }
        else if (mediumInput && !lowInput && !heavyInput && current_InputAction != "medium")
        {
            SetCurrentInputsAction("medium", "<sprite=2>");
        }
        else if (heavyInput && !lowInput && !mediumInput && current_InputAction != "heavy")
        {
            SetCurrentInputsAction( "heavy", "<sprite=4>");
        }
        /*else if (shadowInput && current_InputAction != "Shadow")
        {
            SetCurrentInputsAction("Shadow", "<sprite=12>");
        }
        else if (powerInput && current_InputAction != "Power")
        {
            SetCurrentInputsAction("Power", "<sprite=14>");
        }
        else if (BlockInput && current_InputAction != "Block")
        {
            SetCurrentInputsAction("Block", "<sprite=15>");
        }*/
        else if (!lowInput && !mediumInput && !heavyInput && !shadowInput && !powerInput && !BlockInput && current_InputAction != "")
        {
            SetCurrentInputsAction("", "");
        }

    }

    public void SetCurrentInputsMotion(string setCurrentInput, string setCurrentSpriteInput)
    {
        countInput = 1;

        if (countInput == 1)
        {
            for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
            {
                currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
            }
        }

        current_MotionAction = setCurrentInput;
        current_InputMotion = setCurrentInput;
        sprite_InputMotion = setCurrentSpriteInput;
    }

    public void SetCurrentInputsAction(string setCurrentInput, string setCurrentSpriteInput)
    {
        countInput = 1;

        if (countInput == 1)
        {
            for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
            {
                currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
            }
        }

        current_MotionAction = setCurrentInput;
        current_InputAction = setCurrentInput;
        sprite_InputAction = setCurrentSpriteInput;
    }

    public void StateMotionAction()
    {
        switch(current_State)
        {
            case 0:

                if (current_MotionAction == "" && countInput > 5)
                {
                    current_State = 0;
                }
                else if (current_MotionAction == "up_left")
                {
                    print("Back Jump");
                    state_MotionAction = "Back Jump";
                    current_MotionAction = "";
                    current_State = 1;
                }
                else if (current_MotionAction == "up_right")
                {
                    print("Front Jump");
                    state_MotionAction = "Front Jump";
                    current_MotionAction = "";
                    current_State = 2;
                }
                else if (current_MotionAction == "up")
                {
                    print("Jump");
                    state_MotionAction = "Jump";
                    current_MotionAction = "";
                    current_State = 3;
                }
                else if (current_MotionAction == "down_left")
                {
                    print("Crouched");
                    state_MotionAction = "Crouched";
                    current_MotionAction = "";
                    current_State = 4;
                }
                else if (current_MotionAction == "down_right")
                {
                    print("Crouched");
                    state_MotionAction = "Crouched";
                    current_MotionAction = "";
                    current_State = 5;
                }
                else if (current_MotionAction == "down")
                {
                    print("Crouched");
                    state_MotionAction = "Crouched";
                    current_MotionAction = "";
                    current_State = 6;
                }
                else if (current_MotionAction == "back")
                {
                    print("Move Back");
                    state_MotionAction = "Move Back";
                    current_MotionAction = "";
                    current_State = 7;
                }
                else if (current_MotionAction == "front")
                {
                    print("Move Front");
                    state_MotionAction = "Move Front";
                    current_MotionAction = "";
                    current_State = 8;
                }
                else if (current_MotionAction == "low")
                {
                    print("Attack Low");
                    state_MotionAction = "Attack Low";
                    current_MotionAction = "";
                    current_State = 9;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 10;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 11;
                }
                else if (current_MotionAction == "throw")
                {
                    current_State = 12;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 1:

                if (current_MotionAction == "low")
                {
                    current_State = 13;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 14;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 15;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 2:

                if (current_MotionAction == "low")
                {
                    current_State = 13;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 14;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 15;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 3:

                if (current_MotionAction == "low")
                {
                    current_State = 13;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 14;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 15;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 4:

                if (current_MotionAction == "low")
                {
                    current_State = 16;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 17;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 18;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 5:

                if (current_MotionAction == "low")
                {
                    current_State = 16;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 17;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 18;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 6:

                if (current_MotionAction == "low")
                {
                    current_State = 16;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 17;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 18;
                }
                else if (current_MotionAction == "down_front")
                {
                    current_State = 19;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 7:

                if (current_MotionAction == "back")
                {
                    current_State = 20;
                }
                else if (current_MotionAction == "throw")
                {
                    current_State = 21;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 22;
                }
                else if (current_MotionAction == "front")
                {
                    current_State = 23;
                }
                else if (current_MotionAction == "down_back")
                {
                    current_State = 24;
                }
                else if (current_MotionAction == "low")
                {
                    print("Attack Low");
                    state_MotionAction = "Attack Low";
                    current_MotionAction = "";
                    current_State = 9;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 11;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 8:

                if (current_MotionAction == "front")
                {
                    current_State = 26;
                }
                else if (current_MotionAction == "low")
                {
                    print("Attack Low");
                    state_MotionAction = "Attack Low";
                    current_MotionAction = "";
                    current_State = 9;
                }
                else if (current_MotionAction == "medium")
                {
                    current_State = 10;
                }
                else if (current_MotionAction == "throw")
                {
                    current_State = 12;
                }
                else if (current_MotionAction == "heavy")
                {
                    current_State = 27;
                }
                else if (current_MotionAction == "down_front")
                {
                    current_State = 28;
                }
                else if (current_MotionAction == "down")
                {
                    current_State = 29;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 9:

                if (current_MotionAction == "low")
                {
                    current_State = 25;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 10:
                print("Attack Medium");
                state_MotionAction = "Attack Medium";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 11:
                print("Attack Heavy");
                state_MotionAction = "Attack Heavy";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 12:
                print("Throw");
                state_MotionAction = "Throw";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 13:
                print("Jump Attack Low");
                state_MotionAction = "Jump Attack Low";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 14:
                print("Jump Attack Medium");
                state_MotionAction = "Jump Attack Medium";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 15:
                print("Jump Attack Heavy");
                state_MotionAction = "Jump Attack Heavy";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 16:
                print("Crouched Attack Low");
                state_MotionAction = "Crouched Attack Low";
                current_MotionAction = "";
                current_State = 4;

                break;
            case 17:
                print("Crouched Attack Medium");
                state_MotionAction = "Crouched Attack Medium";
                current_MotionAction = "";
                current_State = 4;

                break;
            case 18:
                print("Crouched Attack Heavy");
                state_MotionAction = "Crouched Attack Heavy";
                current_MotionAction = "";
                current_State = 4;

                break;
            case 19:

                if (current_MotionAction == "front")
                {
                    current_State = 30;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 20:
                print("Back Dash");
                state_MotionAction = "Back Dash";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 21:
                print("Back Throw");
                state_MotionAction = "Back Throw";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 22:
                print("Attack Medium 2");
                state_MotionAction = "Attack Medium 2";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 23:

                if (current_MotionAction == "medium")
                {
                    current_State = 31;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 24:

                if (current_MotionAction == "down")
                {
                    current_State = 32;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 25:
                print("Sequence Attack Low");
                state_MotionAction = "Sequence Attack Low";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 26:
                print("Front Dash");
                state_MotionAction = "Front Dash";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 27:
                print("Attack Heavy 2");
                state_MotionAction = "Attack Heavy 2";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 28:

                if (current_MotionAction == "down")
                {
                    current_State = 29;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 29:

                if (current_MotionAction == "down_front")
                {
                    current_State = 33;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 30:

                if (current_MotionAction == "low" || current_MotionAction == "medium" || current_MotionAction == "heavy")
                {
                    current_State = 34;
                }
                else if (current_MotionAction == "down")
                {
                    current_State = 35;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 31:
                print("Special Attack 1");
                state_MotionAction = "Special Attack 1";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 32:

                if (current_MotionAction == "down_front")
                {
                    current_State = 36;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 33:

                if (current_MotionAction == "front")
                {
                    current_State = 37;
                }
                else if (current_MotionAction == "low" || current_MotionAction == "medium" || current_MotionAction == "heavy")
                {
                    current_State = 38;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 34:
                print("Special Attack 2");
                state_MotionAction = "Special Attack 2";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 35:

                if (current_MotionAction == "down_front")
                {
                    current_State = 39;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 36:

                if (current_MotionAction == "front")
                {
                    current_State = 40;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 37:

                if (current_MotionAction == "low" || current_MotionAction == "medium" || current_MotionAction == "heavy")
                {
                    current_State = 38;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 38:
                print("Special Attack 4");
                state_MotionAction = "Special Attack 4";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 39:

                if (current_MotionAction == "front")
                {
                    current_State = 41;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 40:

                if (current_MotionAction == "low" || current_MotionAction == "medium" || current_MotionAction == "heavy")
                {
                    current_State = 42;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 41:

                if (current_MotionAction == "low" || current_MotionAction == "medium" || current_MotionAction == "heavy")
                {
                    current_State = 43;
                }
                else if (countInput > 5)
                {
                    current_State = 0;
                }

                break;
            case 42:
                print("Special Attack 3");
                state_MotionAction = "Special Attack 3";
                current_MotionAction = "";
                current_State = 0;

                break;
            case 43:

                print("Super");
                state_MotionAction = "Super";
                current_MotionAction = "";
                current_State = 0;

                break;

        }
    }

    #region GetInputs (Callback)

    public void GetDirectionInput(InputAction.CallbackContext callbackContext)
    {
        directionInput = callbackContext.ReadValue<Vector2>();
    }
    /*public void GetRedInput(InputAction.CallbackContext callbackContext)
    {
        redInput = callbackContext.action.triggered;

        if (!redInput && !greenInput && !blueInput)
            canBlackAndWhite = true;

        if (!redInput && !blueInput)
            canMagenta = true;

        if (!redInput && !greenInput)
            canYellow = true;

        if (!redInput)
            canRed = true;

    }

    public void GetGreenInput(InputAction.CallbackContext callbackContext)
    {
        greenInput = callbackContext.action.triggered;

        if (!greenInput && !redInput && !blueInput)
            canBlackAndWhite = true;

        if (!greenInput && !blueInput)
            canCyan = true;

        if (!greenInput && !redInput)
            canYellow = true;

        if (!greenInput)
            canGreen = true;
    }

    public void GetBlueInput(InputAction.CallbackContext callbackContext)
    {
        blueInput = callbackContext.action.triggered;

        if (!blueInput && !redInput && !greenInput)
            canBlackAndWhite = true;

        if (!blueInput && !greenInput)
            canCyan = true;

        if (!blueInput && !redInput)
            canMagenta = true;

        if (!blueInput)
            canBlue = true;
    }
    public void GetPowerInput(InputAction.CallbackContext callbackContext)
    {
        powerInput = callbackContext.action.triggered;

        if (!powerInput)
            canPower = true;
    }
    public void GetBlockInput(InputAction.CallbackContext callbackContext)
    {
        blockInput = callbackContext.action.triggered;

        if (!blockInput)
            canBlock = true;
    }*/

    public void GetLowInput(InputAction.CallbackContext callbackContext)
    {
        lowInput = callbackContext.action.triggered;
    }

    public void GetMediumInput(InputAction.CallbackContext callbackContext)
    {
        mediumInput = callbackContext.action.triggered;
    }

    public void GetHeavyInput(InputAction.CallbackContext callbackContext)
    {
        heavyInput = callbackContext.action.triggered;
    }

    public void GetShadowInput(InputAction.CallbackContext callbackContext)
    {
        shadowInput = callbackContext.action.triggered;
    }

    public void GetPowerInput(InputAction.CallbackContext callbackContext)
    {
        powerInput = callbackContext.action.triggered;
    }

    public void GetBlockInput(InputAction.CallbackContext callbackContext)
    {
        blockInput = callbackContext.action.triggered;
    }

    #endregion

    #region GetAndSetInputs

    public Vector2 DirectionInput
    {
        get { return directionInput; }
        set { directionInput = value; }
    }

    public bool LowInput
    {
        get { return lowInput; }
        set { lowInput = value; }
    }

    public bool MediumInput
    {
        get { return mediumInput; }
        set { mediumInput = value; }
    }

    public bool HeavyInput
    {
        get { return heavyInput; }
        set { heavyInput = value; }
    }

    public bool ShadowInput
    {
        get { return shadowInput; }
        set { shadowInput = value; }
    }

    public bool PowerInput
    {
        get { return powerInput; }
        set { powerInput = value; }
    }

    public bool BlockInput
    {
        get { return blockInput; }
        set { blockInput = value; }
    }

    public string Current_InputMotion
    {
        get { return current_InputMotion; }
        set { current_InputMotion = value; }
    }

    public string Current_InputAction
    {
        get { return current_InputAction; }
        set { current_InputAction = value; }
    }

    public string State_MotionAction
    {
        get { return state_MotionAction; }
        set { state_MotionAction = value; }
    }

    #endregion
}
