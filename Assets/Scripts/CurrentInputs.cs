using System.Collections;
using TMPro;
using UnityEngine;

public class CurrentInputs : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputCurrentText;
    [SerializeField] private string inputCurrent = "";

    [SerializeField] private TextMeshProUGUI inputSpriteCurrentText;
    [SerializeField] private string inputSpriteCurrent = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentInput();
    }

    public void CurrentInput()
    {
        inputCurrentText.text = inputCurrent;
        inputSpriteCurrentText.text = inputSpriteCurrent;

        if (inputCurrent != "")
        {
            StartCoroutine(CooldownInput());
        }
    }
    public IEnumerator CooldownInput()
    {
        yield return new WaitForSeconds(0.7f);
        inputSpriteCurrent = "";
        inputCurrent = "";
    }

    public string InputCurrent
    { 
        get { return inputCurrent; }
        set { inputCurrent = value; }
    }

    public string InputSpriteCurrent
    {
        get { return inputSpriteCurrent; }
        set { inputSpriteCurrent = value; }
    }
}
