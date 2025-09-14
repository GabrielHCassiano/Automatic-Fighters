using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private string currentInput = "";
    private string currentSpriteInput = "";
    private string currentInput2 = "";
    private string currentSpriteInput2 = "";
    private int countInput = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentInputs = GetComponent<CurrentInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        InputCurrent();
    }

    public void InputCurrent()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            print("ok");
            for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
            {
                print("ok " + i);
                currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
            }
        }*/

        if (countInput <= 20)
        {
            currentInputs.InputCurrent[0] = currentSpriteInput + currentSpriteInput2 + "\t\t" + countInput;

            countInput++;
        }

        if (directionInput.y > 0 && directionInput.x < 0 && currentInput != "UpLeft")
        {
            CurrentInputLogic("UpLeft", "<sprite=16>");
        }
        else if (directionInput.y > 0 && directionInput.x > 0 && currentInput != "UpRight")
        {
            CurrentInputLogic("UpRight", "<sprite=17>");
        }
        else if (directionInput.y < 0 && directionInput.x < 0 && currentInput != "DownLeft")
        {
            CurrentInputLogic("DownLeft", "<sprite=18>");
        }
        else if (directionInput.y < 0 && directionInput.x > 0 && currentInput != "DownRight")
        {
            CurrentInputLogic("DownRight", "<sprite=19>");
        }
        else if (directionInput.y > 0 && directionInput.x == 0 && currentInput != "Up")
        {
            CurrentInputLogic("Up", "<sprite=24>");
        }
        else if (directionInput.y < 0 && directionInput.x == 0 && currentInput != "Down")
        {
            CurrentInputLogic("Down", "<sprite=25>");
        }
        else if (directionInput.x < 0 && directionInput.y == 0 && currentInput != "Left")
        {
            CurrentInputLogic("Left", "<sprite=26>");
        }
        else if (directionInput.x > 0 && directionInput.y == 0 && currentInput != "Right")
        {
            CurrentInputLogic("Right", "<sprite=27>");
        }
        /*else if (lowInput && mediumInput && heavyInput && currentInput != "BlackAndWhite")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "BlackAndWhite";
            currentSpriteInput = "<sprite=13>";
        }
        else if (!lowInput && mediumInput && heavyInput && currentInput != "Cyan")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Cyan";
            currentSpriteInput = "<sprite=6>";
        }
        else if (lowInput && !mediumInput && heavyInput && currentInput != "Magenta")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Magenta";
            currentSpriteInput = "<sprite=8>";
        }
        else if (lowInput && mediumInput && !heavyInput && currentInput != "Yellow")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Yellow";
            currentSpriteInput = "<sprite=10>";
        }
        else if (lowInput && !mediumInput && !heavyInput && currentInput != "Low")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Low";
            currentSpriteInput = "<sprite=0>";
        }
        else if (mediumInput && !lowInput && !heavyInput && currentInput != "Medium")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Medium";
            currentSpriteInput = "<sprite=2>";
        }
        else if (heavyInput && !lowInput && !mediumInput && currentInput != "Heavy")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Heavy";
            currentSpriteInput = "<sprite=4>";
        }
        else if (shadowInput && currentInput != "Shadow")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Shadow";
            currentSpriteInput = "<sprite=12>";
        }
        else if (powerInput && currentInput != "Power")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Power";
            currentSpriteInput = "<sprite=14>";
        }
        else if (BlockInput && currentInput != "Block")
        {
            countInput = 0;

            if (countInput == 0)
            {
                for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
                {
                    currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
                }
            }

            currentInput = "Block";
            currentSpriteInput = "<sprite=15>";
        }
        */
        else if (directionInput.x == 0 && directionInput.y == 0 && !lowInput && !mediumInput && !heavyInput && !shadowInput && !powerInput && !BlockInput && currentInput != "")
        {
            CurrentInputLogic("", "");
        }

        test2();

    }

    public void test2()
    {
        if (lowInput && mediumInput && heavyInput && currentInput2 != "BlackAndWhite")
        {
            CurrentInputLogic2("BlackAndWhite", "<sprite=13");
        }
        else if (!lowInput && mediumInput && heavyInput && currentInput2 != "Cyan")
        {
            CurrentInputLogic2("Cyan", "<sprite=6>");
        }
        else if (lowInput && !mediumInput && heavyInput && currentInput2 != "Magenta")
        {
            CurrentInputLogic2("Magenta", "<sprite=8>");
        }
        else if (lowInput && mediumInput && !heavyInput && currentInput2 != "Yellow")
        {
            CurrentInputLogic2("Yellow", "<sprite=10>");
        }
        else if (lowInput && !mediumInput && !heavyInput && currentInput2 != "Low")
        {
            CurrentInputLogic2("Low", "<sprite=0>");
        }
        else if (mediumInput && !lowInput && !heavyInput && currentInput2 != "Medium")
        {
            CurrentInputLogic2("Medium", "<sprite=2>");
        }
        else if (heavyInput && !lowInput && !mediumInput && currentInput2 != "Heavy")
        {
            CurrentInputLogic2( "Heavy", "<sprite=4>");
        }
        else if (shadowInput && currentInput2 != "Shadow")
        {
            CurrentInputLogic2("Shadow", "<sprite=12>");
        }
        else if (powerInput && currentInput2 != "Power")
        {
            CurrentInputLogic2("Power", "<sprite=14>");
        }
        else if (BlockInput && currentInput2 != "Block")
        {
            CurrentInputLogic2("Block", "<sprite=15>");
        }

        else if (directionInput.x == 0 && directionInput.y == 0 && !lowInput && !mediumInput && !heavyInput && !shadowInput && !powerInput && !BlockInput && currentInput2 != "")
        {
            CurrentInputLogic2("", "");
        }

    }

    public void CurrentInputLogic(string setCurrentInput, string setCurrentSpriteInput)
    {
        countInput = 0;

        if (countInput == 0)
        {

            for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
            {
                currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
            }
        }

        currentInput = setCurrentInput;
        currentSpriteInput = setCurrentSpriteInput;
    }

    public void CurrentInputLogic2(string setCurrentInput, string setCurrentSpriteInput)
    {
        countInput = 0;

        if (countInput == 0)
        {

            for (int i = currentInputs.InputCurrent.Length - 1; i > 0; i--)
            {
                currentInputs.InputCurrent[i] = currentInputs.InputCurrent[i - 1];
            }
        }

        currentInput2 = setCurrentInput;
        currentSpriteInput2 = setCurrentSpriteInput;
    }

    #region GetInputs (Callback)

    public void GetDirectionInput(InputAction.CallbackContext callbackContext)
    {
        directionInput = callbackContext.ReadValue<Vector2>();

        if (directionInput == Vector2.zero)
        {
            canDirectionUpLeft = true;
            canDirectionUpRight = true;
            canDirectionDownLeft = true;
            canDirectionDownRight = true;
            canDirectionUp = true;
            canDirectionDown = true;
            canDirectionLeft = true;
            canDirectionRight = true;

        }
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

    #endregion
}
