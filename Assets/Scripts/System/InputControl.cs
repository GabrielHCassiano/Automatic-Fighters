using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InputControl : MonoBehaviour
{
    [SerializeField] private Vector2 move, direction;
    [SerializeField] private bool button1, button2, heavyAttack, button3, lightAttack, button4, lt, lb, rt, rb, start, back, cancel;
    private string inputName;

    [Header("Buttons IDs Declarations")]
    [SerializeField] private List<string> keyboardIDs;
    [SerializeField] private List<string> playstationIDs;
    [SerializeField] private List<string> xboxIDs;
    [SerializeField] private List<string> nintendoIDs;
    [SerializeField] private List<string> genericIDs;

    private string idButton1, idButton2, idButton3, idButton4, idlt, idrt, idStart, idBack, idLeft, idRight, idSpecial;

    private bool canButton;
    [SerializeField] private string codeButton;

    [SerializeField] private TextMeshProUGUI textCodeButton;

    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();  
    }

    // Update is called once per frame
    void Update()
    {
        TyperInput();
        //GetCodeButton();
        SetCodeButton();
    }

    #region TyperInput

    public void TyperInput()
    {
        if (playerInput.devices[0] is Keyboard)
        {
                inputName = "Keyboard";
                idButton4 = keyboardIDs[0];
                idButton1 = keyboardIDs[1];
                idButton2 = keyboardIDs[2];
                idButton3 = keyboardIDs[3];
                idlt = keyboardIDs[4];
                idrt = keyboardIDs[5];
                idStart = keyboardIDs[6];
                idBack = keyboardIDs[7];
                idLeft = keyboardIDs[8];
                idRight = keyboardIDs[9];
                idSpecial = keyboardIDs[10];
        }
        else if (playerInput.devices[0].description.manufacturer != "")
        {
            switch (playerInput.devices[0].description.manufacturer)
            {
                case "Sony Interactive Entertainment":
                    inputName = "Playstation";
                    idButton4 = playstationIDs[0];
                    idButton1 = playstationIDs[1];
                    idButton2 = playstationIDs[2];
                    idButton3 = playstationIDs[3];
                    idlt = playstationIDs[4];
                    idrt = playstationIDs[5];
                    idStart = playstationIDs[6];
                    idBack = playstationIDs[7];
                    idLeft = playstationIDs[8];
                    idRight = playstationIDs[9];
                    idSpecial = playstationIDs[10];
                    break;
                case "Nintendo":
                    inputName = "Nintendo";
                    idButton4 = nintendoIDs[0];
                    idButton1 = nintendoIDs[1];
                    idButton2 = nintendoIDs[2];
                    idButton3 = nintendoIDs[3];
                    idlt = nintendoIDs[4];
                    idrt = nintendoIDs[5];
                    idStart = nintendoIDs[6];
                    idBack = nintendoIDs[7];
                    idLeft = nintendoIDs[8];
                    idRight = nintendoIDs[9];
                    idSpecial = nintendoIDs[10];
                    break;
                default:
                    inputName = "Generic";
                    idButton4 = genericIDs[0];
                    idButton1 = genericIDs[1];
                    idButton2 = genericIDs[2];
                    idButton3 = genericIDs[3];
                    idlt = genericIDs[4];
                    idrt = genericIDs[5];
                    idStart = genericIDs[6];
                    idBack = genericIDs[7];
                    idLeft = genericIDs[8];
                    idRight = genericIDs[9];
                    idSpecial = genericIDs[10];
                    break;
            }
        }
        else
        {
            if (playerInput.devices[0] is XInputController)
            {
                inputName = "Xbox";
                idButton4 = xboxIDs[0];
                idButton1 = xboxIDs[1];
                idButton2 = xboxIDs[2];
                idButton3 = xboxIDs[3];
                idlt = xboxIDs[4];
                idrt = xboxIDs[5];
                idStart = xboxIDs[6];
                idBack = xboxIDs[7];
                idLeft = xboxIDs[8];
                idRight = xboxIDs[9];
                idSpecial = xboxIDs[10];
            }
            else
            {
                inputName = "Generic";
                idButton4 = playstationIDs[0];
                idButton1 = playstationIDs[1];
                idButton2 = playstationIDs[2];
                idButton3 = playstationIDs[3];
                idlt = playstationIDs[4];
                idrt = playstationIDs[5];
                idStart = playstationIDs[6];
                idBack = playstationIDs[7];
                idLeft = playstationIDs[8];
                idRight = playstationIDs[9];
                idSpecial = playstationIDs[10];
            }
        }
    }

    #endregion

    #region Inputs

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        direction = context.ReadValue<Vector2>();
    }

    // Bot?es pressionados no frame;
    public void OnButton1(InputAction.CallbackContext context)
    {
        button1 = context.action.triggered;
    }
    public void OnButton2(InputAction.CallbackContext context)
    {
        button2 = context.action.triggered;
        heavyAttack = context.action.triggered;
    }
    public void OnButton3(InputAction.CallbackContext context)
    {
        button3 = context.action.triggered;
        lightAttack = context.action.triggered;
    }
    public void OnButton4(InputAction.CallbackContext context)
    {
        button4 = context.action.triggered;
    }
    public void OnLT(InputAction.CallbackContext context)
    {
        lt = context.action.triggered;
    }
    public void OnLB(InputAction.CallbackContext context)
    {
        lb = context.action.triggered;
    }
    public void OnRT(InputAction.CallbackContext context)
    {
        rt = context.action.triggered;
    }
    public void OnRB(InputAction.CallbackContext context)
    {
        rb = context.action.triggered;
    }
    public void OnStart(InputAction.CallbackContext context)
    {
        start = context.action.triggered;
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        back = context.action.triggered;
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        cancel = context.action.triggered;
    }

    #endregion

    #region Code Button

    public void GetCodeButton()
    {
        if (FindObjectOfType<Camera>() == null)
            return;
        else
            textCodeButton.GetComponentInParent<Canvas>().worldCamera = FindObjectOfType<Camera>();

        textCodeButton.text = codeButton;
    }

    public void SetCodeButton()
    {

        if (button3 == true && canButton)
        {
            StopAllCoroutines();
            codeButton += "X ";
            button3 = false;
            canButton = false;
        }

        if (button2 == true && canButton)
        {
            StopAllCoroutines();
            codeButton += "O ";
            button2 = false;
            canButton = false;
        }

        if (direction.x > 0 && direction.y < 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "\\V ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.x > 0 && direction.y > 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "/A ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.x < 0 && direction.y < 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "/V ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.x < 0 && direction.y > 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "\\A ";
            direction = Vector2.zero;
            canButton = false;
        }

        if (direction.x < 0 && direction.y == 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "< ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.x > 0 && direction.y == 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "> ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.y < 0 && direction.x == 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "V ";
            direction = Vector2.zero;
            canButton = false;
        }
        if (direction.y > 0 && direction.x == 0 && canButton)
        {
            StopAllCoroutines();
            codeButton += "A ";
            direction = Vector2.zero;
            canButton = false;
        }

        if (!canButton)
            StartCoroutine(ButtonDelay());

        if (codeButton != "")
            StartCoroutine(CodeClean());
    }

    public IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(0.08f);
        canButton = true;
    }

    public IEnumerator CodeClean()
    {
        yield return new WaitForSeconds(0.3f);
        codeButton = "";
    }

    #endregion

    public Vector2 Move
    {
        get { return move; }
        set { move = value; }
    }

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public bool Button1
    {
        get { return button1; }
        set { button1 = value; }
    }

    public bool Button2
    {
        get { return button2; }
        set { button2 = value; }
    }
    public bool HeavyAttack
    {
        get { return heavyAttack; }
        set { heavyAttack = value; }
    }

    public bool Button3
    {
        get { return button3; }
        set { button3 = value; }
    }

    public bool LightAttack
    {
        get { return lightAttack; }
        set { lightAttack = value; }
    }

    public bool Button4
    {
        get { return button4; }
        set { button4 = value; }
    }

    public bool Lt
    {
        get { return lt; }
        set { lt = value; }
    }

    public bool Lb
    {
        get { return lb; }
        set { lb = value; }
    }

    public bool Rt
    {
        get { return rt; }
        set { rt = value; }
    }

    public bool Rb
    {
        get { return rb; }
        set { rb = value; }
    }

    public bool ButtonStart
    {
        get { return start; }
        set { start = value; }
    }

    public bool Back
    {
        get { return back; }
        set { back = value; }
    }

    public string IdButton1
    {
        get { return idButton1; }
        set { idButton1 = value; }
    }

    public string IdButton2
    {
        get { return idButton2; }
        set { idButton2 = value; }
    }

    public string IdButton3
    {
        get { return idButton3; }
        set { idButton3 = value; }
    }

    public string IdButton4
    {
        get { return idButton4; }
        set { idButton4 = value; }
    }

    public string IdLT
    {
        get { return idlt; }
        set { idlt = value; }
    }

    public string IdRT
    {
        get { return idrt; }
        set { idrt = value; }
    }
    public string IdStart
    {
        get { return idStart; }
        set { idStart = value; }
    }

    public string IdBack
    {
        get { return idBack; }
        set { idBack = value; }
    }

    public string IdLeft
    {
        get { return idLeft; }
        set { idLeft = value; }
    }
    public string IdRight
    {
        get { return idRight; }
        set { idRight = value; }
    }

    public string IdSpecial
    {
        get { return idSpecial; }
        set { idSpecial = value; }
    }

    public bool Cancel
    {
        get { return cancel; }
        set { cancel = value; }
    }

    public string CodeButton
    {
        get { return codeButton; }
        set { codeButton = value; }
    }

}
