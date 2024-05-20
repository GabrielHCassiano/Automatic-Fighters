using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deselect : MonoBehaviour, IDeselectHandler
{
    [SerializeField] private Back back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    public void OnDeselect(BaseEventData eventData)
    {
        back.enabled = true;
        FindObjectOfType<InputControl>().Cancel = false;
    }
}
