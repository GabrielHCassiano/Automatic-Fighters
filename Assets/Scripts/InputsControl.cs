using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputCurrentText;
    [SerializeField] private string inputCurrent = "";

    [SerializeField] private Vector2 directionInput;
    [SerializeField] private bool redInput, greenInput, blueInput, powerInput, blockInput;

    [SerializeField] private bool canDirectionUpLeft, canDirectionUpRight, canDirectionDownLeft, canDirectionDownRight,
        canDirectionUp, canDirectionDown, canDirectionLeft, canDirectionRight,
        canRed, canGreen, canBlue, canPower, canBlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputCurrent();
    }

    public void InputCurrent()
    {
        inputCurrentText.text = inputCurrent;

        if (directionInput.y > 0 && directionInput.x < 0 && canDirectionUpLeft)  
        {
            StopAllCoroutines();
            canDirectionUpLeft = false;
            inputCurrent += " UpLeft";
        }

        if (directionInput.y > 0 && directionInput.x > 0 && canDirectionUpRight)
        {
            StopAllCoroutines();
            canDirectionUpRight = false;
            inputCurrent += " UpRight";
        }

        if (directionInput.y < 0 && directionInput.x < 0 && canDirectionDownLeft)
        {
            StopAllCoroutines();
            canDirectionDownLeft = false;
            inputCurrent += " DownLeft";
        }

        if (directionInput.y < 0 && directionInput.x > 0 && canDirectionDownRight)
        {
            StopAllCoroutines();
            canDirectionDownRight = false;
            inputCurrent += " DownRight";
        }

        if (directionInput.y > 0 && directionInput.x == 0 && canDirectionUp)
        {
            StopAllCoroutines();
            canDirectionUp = false;
            inputCurrent += " Up";
        }

        if (directionInput.y < 0 && directionInput.x == 0 && canDirectionDown)
        {
            StopAllCoroutines();
            canDirectionDown = false;
            inputCurrent += " Down";
        }

        if (directionInput.x < 0 && directionInput.y == 0 && canDirectionLeft)
        {
            StopAllCoroutines();
            canDirectionLeft = false;
            inputCurrent += " Left";
        }

        if (directionInput.x > 0 && directionInput.y == 0 && canDirectionRight)
        {
            StopAllCoroutines();
            canDirectionRight = false;
            inputCurrent += " Right";
        }

        if (redInput && canRed)
        {
            StopAllCoroutines();
            canRed = false;
            inputCurrent += " Red";
            StartCoroutine(CooldownPositve());
        }

        if (greenInput && canGreen)
        {
            StopAllCoroutines();
            canGreen = false;
            inputCurrent += " Green";
            StartCoroutine(CooldownPositve());
        }

        if (blueInput && canBlue)
        {
            StopAllCoroutines();
            canBlue = false;
            inputCurrent += " Blue";
            StartCoroutine(CooldownPositve());
        }

        if (powerInput && canPower)
        {
            StopAllCoroutines();
            canPower = false;
            inputCurrent += " Power";
        }

        if (BlockInput && canBlock)
        {
            StopAllCoroutines();
            canBlock = false;
            inputCurrent += " Block";
        }

        if (inputCurrent != "")
        {
            //StartCoroutine(CooldownInput());
        }
    }

    public IEnumerator CooldownInput()
    {
        yield return new WaitForSeconds(0.5f);
        inputCurrent = "";
    }

    public IEnumerator CooldownPositve()
    {
        yield return new WaitForSeconds(0.1f);
        if (redInput)
            inputCurrent += " +Red";
        if (greenInput)
            inputCurrent += " +Green";
        if (blueInput)
            inputCurrent += " +Blue";
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

        if (!redInput)
            canRed = true;
    }

    public void GetGreenInput(InputAction.CallbackContext callbackContext)
    {
        greenInput = callbackContext.action.triggered;

        if (!greenInput)
            canGreen = true;
    }

    public void GetBlueInput(InputAction.CallbackContext callbackContext)
    {
        blueInput = callbackContext.action.triggered;

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
