using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class InputsControl : MonoBehaviour
{

    [SerializeField] private Vector2 directionInput;
    [SerializeField] private bool redInput, greenInput, blueInput, powerInput, blockInput;

    [SerializeField] private bool canDirectionUpLeft, canDirectionUpRight, canDirectionDownLeft, canDirectionDownRight,
        canDirectionUp, canDirectionDown, canDirectionLeft, canDirectionRight,
        canRed, canGreen, canBlue, canCyan, canMagenta, canYellow, canBlackAndWhite, canPower, canBlock;

    private bool inMultipleInputs, inBlackAndWhite;

    private CurrentInputs currentInputs;

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
        if (directionInput.y > 0 && directionInput.x < 0 && canDirectionUpLeft)  
        {
            currentInputs.StopAllCoroutines();
            canDirectionUpLeft = false;
            StartCoroutine(CooldownPositve("UpLeft"));
        }

        if (directionInput.y > 0 && directionInput.x > 0 && canDirectionUpRight)
        {
            currentInputs.StopAllCoroutines();
            canDirectionUpRight = false;
            StartCoroutine(CooldownPositve("UpRight"));
        }

        if (directionInput.y < 0 && directionInput.x < 0 && canDirectionDownLeft)
        {
            currentInputs.StopAllCoroutines();
            canDirectionDownLeft = false;
            StartCoroutine(CooldownPositve("DownLeft"));
        }

        if (directionInput.y < 0 && directionInput.x > 0 && canDirectionDownRight)
        {
            currentInputs.StopAllCoroutines();
            canDirectionDownRight = false;
            StartCoroutine(CooldownPositve("DownRight"));
        }

        if (directionInput.y > 0 && directionInput.x == 0 && canDirectionUp)
        {
            currentInputs.StopAllCoroutines();
            canDirectionUp = false;
            StartCoroutine(CooldownPositve("Up"));
        }

        if (directionInput.y < 0 && directionInput.x == 0 && canDirectionDown)
        {
            currentInputs.StopAllCoroutines();
            canDirectionDown = false;
            StartCoroutine(CooldownPositve("Down"));
        }

        if (directionInput.x < 0 && directionInput.y == 0 && canDirectionLeft)
        {
            currentInputs.StopAllCoroutines();
            canDirectionLeft = false;
            StartCoroutine(CooldownPositve("Left"));
        }

        if (directionInput.x > 0 && directionInput.y == 0 && canDirectionRight)
        {
            currentInputs.StopAllCoroutines();
            canDirectionRight = false;
            StartCoroutine(CooldownPositve("Right"));
        }

        if (redInput && greenInput && blueInput && canBlackAndWhite)
        {
            currentInputs.StopAllCoroutines();
            inBlackAndWhite = true;
            canBlackAndWhite = false;
            canRed = false;
            canGreen = false;
            canBlue = false;
            canCyan = false;
            canMagenta = false;
            canYellow = false;
            StartCoroutine(CooldownPositve("BlackAndWhite"));
        }

        if (!redInput && greenInput && blueInput && canCyan)
        {
            currentInputs.StopAllCoroutines();
            inMultipleInputs = true;
            canCyan = false;
            canGreen = false;
            canBlue = false;
            StartCoroutine(CooldownPositve("Cyan"));
        }

        if (redInput && !greenInput && blueInput && canMagenta)
        {
            currentInputs.StopAllCoroutines();
            inMultipleInputs = true;
            canMagenta = false;
            canRed = false;
            canBlue = false;
            StartCoroutine(CooldownPositve("Magenta"));
        }

        if (redInput && greenInput && !blueInput && canYellow)
        {
            currentInputs.StopAllCoroutines();
            inMultipleInputs = true;
            canYellow = false;
            canRed = false;
            canGreen = false;
            StartCoroutine(CooldownPositve("Yellow"));
        }

        if (redInput && !greenInput && !blueInput && canRed)
        {
            currentInputs.StopAllCoroutines();
            canRed = false;
            StartCoroutine(CooldownPositve("Red"));
        }

        if (greenInput && !redInput && !blueInput && canGreen)
        {
            currentInputs.StopAllCoroutines();
            canGreen = false;
            StartCoroutine(CooldownPositve("Green"));
        }

        if (blueInput && !redInput && !greenInput && canBlue)
        {
            currentInputs.StopAllCoroutines();
            canBlue = false;
            StartCoroutine(CooldownPositve("Blue"));
        }

        if (powerInput && canPower)
        {
            currentInputs.StopAllCoroutines();
            canPower = false;
            StartCoroutine(CooldownPositve("Power"));
        }

        if (BlockInput && canBlock)
        {
            currentInputs.StopAllCoroutines();
            canBlock = false;
            StartCoroutine(CooldownPositve("Block"));
        }
    }

    public IEnumerator CooldownPositve(string typerInput)
    {
        yield return new WaitForSeconds(0.15f);

        switch (typerInput)
        {
            case "UpLeft":

                if (directionInput.y > 0 && directionInput.x < 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=20>";
                    currentInputs.InputCurrent += " +UpLeft";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=16>";
                    currentInputs.InputCurrent += " UpLeft";
                }

                break;

            case "UpRight":

                if (directionInput.y > 0 && directionInput.x > 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=21>";
                    currentInputs.InputCurrent += " +UpRight";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=17>";
                    currentInputs.InputCurrent += " UpRight";
                }

                break;

            case "DownLeft":

                if (directionInput.y < 0 && directionInput.x < 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=22>";
                    currentInputs.InputCurrent += " +DownLeft";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=18>";
                    currentInputs.InputCurrent += " DownLeft";
                }

                break;

            case "DownRight":

                if (directionInput.y < 0 && directionInput.x > 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=23>";
                    currentInputs.InputCurrent += " +DownRight";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=19>";
                    currentInputs.InputCurrent += " DownRight";
                }

                break;

            case "Up": 

                if (directionInput.y > 0 && directionInput.x == 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=28>";
                    currentInputs.InputCurrent += " +Up";
                }
                else 
                {
                    currentInputs.InputSpriteCurrent += " <sprite=24>";
                    currentInputs.InputCurrent += " Up";
                }

                break;

            case "Down":

                if (directionInput.y < 0 && directionInput.x == 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=29>";
                    currentInputs.InputCurrent += " +Down";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=25>";
                    currentInputs.InputCurrent += " Down";
                }

                break;

            case "Left":

                if (directionInput.x < 0 && directionInput.y == 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=30>";
                    currentInputs.InputCurrent += " +Left";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=26>";
                    currentInputs.InputCurrent += " Left";
                }


                break;

            case "Right":

                if (directionInput.x > 0 && directionInput.y == 0)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=31>";
                    currentInputs.InputCurrent += " +Right";
                }
                else 
                {
                    currentInputs.InputSpriteCurrent += " <sprite=27>";
                    currentInputs.InputCurrent += " Right";
                }

                break;

            case "BlackAndWhite":

                if (redInput && greenInput && blueInput)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=13>";
                    currentInputs.InputCurrent += " White";
                }
                else
                {
                    currentInputs.InputSpriteCurrent += " <sprite=12>";
                    currentInputs.InputCurrent += " Black";
                }

                inBlackAndWhite = false;

                break;

            case "Cyan":

                if (greenInput && blueInput && !redInput && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=7>";
                    currentInputs.InputCurrent += " +Cyan";
                }
                else if (!inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=6>";
                    currentInputs.InputCurrent += " Cyan";
                }

                inMultipleInputs = false;

                break;

            case "Magenta":

                if (redInput && blueInput && !greenInput && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=9>";
                    currentInputs.InputCurrent += " +Magenta";
                }
                else if (!inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=8>";
                    currentInputs.InputCurrent += " Magenta";
                }

                inMultipleInputs = false;

                break;

            case "Yellow":

                if (redInput && greenInput && !blueInput && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=11>";
                    currentInputs.InputCurrent += " +Yellow";
                }
                else if (!inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=10>";
                    currentInputs.InputCurrent += " Yellow";
                }

                inMultipleInputs = false;

                break;

            case "Red":

                if (redInput && !greenInput && !blueInput && !inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=1>";
                    currentInputs.InputCurrent += " +Red";
                }
                else if (!inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=0>";
                    currentInputs.InputCurrent += " Red";
                }

                break;

            case "Green":

                if (greenInput && !redInput && !blueInput && !inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=3>";
                    currentInputs.InputCurrent += " +Green";
                }
                else if (!inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=2>";
                    currentInputs.InputCurrent += " Green";
                }     

                break;

            case "Blue":

                if (blueInput && !redInput && !greenInput && !inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=5>";
                    currentInputs.InputCurrent += " +Blue";
                }
                else if (!inMultipleInputs && !inBlackAndWhite)
                {
                    currentInputs.InputSpriteCurrent += " <sprite=4>";
                    currentInputs.InputCurrent += " Blue";
                }

                break;

            case "Power":

                currentInputs.InputSpriteCurrent += " <sprite=14>";
                currentInputs.InputCurrent += " Power";

                break;

            case "Block":

                currentInputs.InputSpriteCurrent += " <sprite=15>";
                currentInputs.InputCurrent += " Block";

                break;
        }
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
    public void GetRedInput(InputAction.CallbackContext callbackContext)
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
    }

    #endregion

    #region GetAndSetInputs

    public Vector2 DirectionInput
    {
        get { return directionInput; }
        set { directionInput = value; }
    }

    public bool RedInput
    {
        get { return redInput; }
        set { redInput = value; }
    }

    public bool GreenInput
    {
        get { return greenInput; }
        set { greenInput = value; }
    }

    public bool BlueInput
    {
        get { return blueInput; }
        set { blueInput = value; }
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
