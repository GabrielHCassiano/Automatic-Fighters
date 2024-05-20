using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private PlayerCombat playerCombat;
    private int maxLife = 200;
    private int life;

    [SerializeField] private Slider lifeSlider;

    private int posture = 0;

    private int special = 0;

    private int damageHit;
    private int damageBlock;

    private bool lose;

    private int itemQ = 0;
    [SerializeField] private Image item;
    [SerializeField] private TextMeshProUGUI textItemQ;
    private int coins = 0;
    [SerializeField] private TextMeshProUGUI textCoins;
    private int bonus1 = 0;
    private int bonus2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
        life = maxLife;

        coins = PlayerPrefs.GetInt("Coins" , 0);
        bonus1 = PlayerPrefs.GetInt("Bonus1", 0);
        bonus2 = PlayerPrefs.GetInt("Bonus2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        LifeLogic();
        ItemLogic();
        LoseLogic();
    }

    public void ItemLogic()
    {
        textCoins.text = coins.ToString();
        textItemQ.text = itemQ.ToString();

        if (itemQ > 0)
            item.gameObject.SetActive(true);
        else
            item.gameObject.SetActive(false);
    }

    public void LifeLogic()
    {
        lifeSlider.value = (float)life / maxLife;

        if (life <= 0)
            lose = true;
        if (life > maxLife)
            life = maxLife;
    }

    public void LoseLogic()
    {
        if (lose)
        {
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Bonus1", bonus1);
            PlayerPrefs.SetInt("Bonus2", bonus2);
            SceneManager.LoadScene("Menu");
        }
    }

    public void Damage(EnemyStatus enemyStatus, Collider2D collider)
    {
        if (playerCombat.InBlock)
        {
            life -= enemyStatus.DamageBlock;
        }
        else
        {
            life -= enemyStatus.DamageHit;
        }
    }

    public int Life
    { 
        get { return life; }
        set { life = value; }
    }

    public int Posture
    {
        get { return posture; }
        set { posture = value; }
    }

    public int Special
    {
        get { return special; }
        set { special = value; }
    }

    public int DamageHit
    {
        get { return damageHit; }
        set { damageHit = value; }
    }

    public int DamageBlock
    {
        get { return damageBlock; }
        set { damageBlock = value; }
    }

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public int Bonus1
    {
        get { return bonus1; }
        set { bonus1 = value; }
    }
    public int Bonus2
    {
        get { return bonus2; }
        set { bonus2 = value; }
    }

    public int ItemQ
    {
        get { return itemQ; }
        set { itemQ = value; }
    }

    public bool Lose
    { 
        get { return lose; } 
        set { lose = value; } 
    }
}
