using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    [SerializeField] private Button bonus;

    private int coins, bonus1, bonus2;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        bonus1 = PlayerPrefs.GetInt("Bonus1");
        bonus2 = PlayerPrefs.GetInt("Bonus2");
    }

    // Update is called once per frame
    void Update()
    {
        Bonus();
    }

    void Bonus()
    {
        if (coins >= 100 && bonus1 >= 10 && bonus2 >= 2)
        {
            bonus.interactable = true;
        }
    }
}
