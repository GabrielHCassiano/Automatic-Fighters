using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsSprites : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textInputs;
    private InputControl inputControl;
    // Start is called before the first frame update
    void Start()
    {
        inputControl = FindObjectOfType<InputControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    public void Inputs()
    {
        textInputs[0].text = "<size=36><sprite=" + inputControl.IdLeft + "></size><size=36><size=36><sprite=" + inputControl.IdRight + "></size><size=36>";
        textInputs[1].text = "<size=36><sprite=" + inputControl.IdLeft + "></size><size=36><size=36><sprite=" + inputControl.IdLeft + "></size><size=36><size=36> <sprite=" + inputControl.IdRight + "></size><size=36><size=36><sprite=" + inputControl.IdRight + "></size><size=36>";
        textInputs[2].text = "<size=36><sprite=" + inputControl.IdLT + "></size><size=36>";
        textInputs[3].text = "<size=36><sprite=" + inputControl.IdButton1 + "></size><size=36>";
        textInputs[4].text = "<size=36><sprite=" + inputControl.IdButton3 + "></size><size=36>";
        textInputs[5].text = "<size=36><sprite=" + inputControl.IdButton2 + "></size><size=36>";
        textInputs[6].text = "<size=36><sprite=" + inputControl.IdRT + "></size><size=36>";
        textInputs[7].text = "<size=36><sprite=" + inputControl.IdSpecial + "></size><size=36><size=36><sprite=" + inputControl.IdButton3 + "></size><size=36>";
    }
}
