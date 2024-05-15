using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using System.Collections.Generic;

public class InputControl : MonoBehaviour
{
    [SerializeField] private Vector2 move, direction;
    [SerializeField] private bool button1, button2, button3, button4, back;
    
    private string inputName;

    [Header("Buttons IDs Declarations")]
    [SerializeField] private List<string> keyboardIDs;
    [SerializeField] private List<string> playstationIDs;
    [SerializeField] private List<string> xboxIDs;
    [SerializeField] private List<string> nintendoIDs;
    [SerializeField] private List<string> genericIDs;

    private string idButton1, idButton2, idButton3, idButton4;

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
        GetCodeButton();
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
                    break;
                case "Nintendo":
                    inputName = "Nintendo";
                    idButton4 = nintendoIDs[0];
                    idButton1 = nintendoIDs[1];
                    idButton2 = nintendoIDs[2];
                    idButton3 = nintendoIDs[3];
                    break;
                default:
                    inputName = "Generic";
                    idButton4 = genericIDs[0];
                    idButton1 = genericIDs[1];
                    idButton2 = genericIDs[2];
                    idButton3 = genericIDs[3];
                    break;
            }
        }
        else // os controles do xbox n tem a empresa que fez eles, KKKKKKKKKKKKKKKKKKKKKKK
        {
            if (playerInput.devices[0] is XInputController)
            {
                inputName = "Xbox";
                idButton4 = xboxIDs[0];
                idButton1 = xboxIDs[1];
                idButton2 = xboxIDs[2];
                idButton3 = xboxIDs[3];
            }
            else
            {
                inputName = "Generic";
                idButton4 = playstationIDs[0];
                idButton1 = playstationIDs[1];
                idButton2 = playstationIDs[2];
                idButton3 = playstationIDs[3];
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
    }
    public void OnButton3(InputAction.CallbackContext context)
    {
        button3 = context.action.triggered;
    }
    public void OnButton4(InputAction.CallbackContext context)
    {
        button4 = context.action.triggered;
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        back = context.action.triggered;
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
        yield return new WaitForSeconds(0.1f);
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

    public bool Button3
    {
        get { return button3; }
        set { button3 = value; }
    }

    public bool Button4
    {
        get { return button4; }
        set { button4 = value; }
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

    public bool Back
    {
        get { return back; }
        set { back = value; }
    }

    public string CodeButton
    {
        get { return codeButton; }
        set { codeButton = value; }
    }

}
