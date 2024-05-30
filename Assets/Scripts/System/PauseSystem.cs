using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    private InputControl inputControl;

    [SerializeField] private GameObject panel;

    private bool inPause = false;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = FindObjectOfType<InputControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    public void Resume()
    {
       inPause = false;
    }

    public void Pause()
    {
        panel.SetActive(inPause);

        if (inputControl.Back)
        {
            inputControl.Back = false;
            inPause = !inPause;
        }

        if (inPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
