using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    private Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<InputControl>() != null && FindObjectOfType<InputControl>().Back == true)
        {
            backButton.onClick.Invoke();
            FindObjectOfType<InputControl>().Back = false;
        }
    }
}
