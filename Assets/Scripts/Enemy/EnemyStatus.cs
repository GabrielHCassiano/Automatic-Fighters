using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.PlasticSCM.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private EnemyCombat enemyCombat;
    private int maxLife = 100;
    private int life;

    private bool lose = false;

    private int posture = 0;

    private int special = 0;

    private int damageHit;
    private int damageBlock;

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject coca;
    [SerializeField] private GameObject bonus1;
    [SerializeField] private GameObject bonus2;

    // Start is called before the first frame update
    void Start()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        print(life);
        Dead();
    }

    public void Dead()
    {
        if (life <= 0 && lose == false)
        {
            lose = true;
            Random.InitState((int)System.DateTime.Now.Ticks);

            int randomCoin = Random.Range(1, 11);
            for (int i = 0; i < randomCoin; i++)
            {
                Instantiate(coin, transform.position + new Vector3(-0.5f, 0.4f, 0), transform.rotation);
            }

            int randomBonus = Random.Range(0, 51);
            if (randomBonus >= 30 && randomBonus < 45)
                Instantiate(coca, transform.position + new Vector3(0, 0.4f, 0), transform.rotation);
            if (randomBonus >= 45 && randomBonus <= 49)
                Instantiate(bonus1, transform.position + new Vector3(0, 0.4f, 0), transform.rotation);
            if (randomBonus == 50)
                Instantiate(bonus2, transform.position + new Vector3(0, 0.4f, 0), transform.rotation);

            FindObjectOfType<PlayerStatus>().Score += 1;

            SpawnEnemy.Instance.EnemyQ -= 1;

            Destroy(gameObject);
            //gameObject.SetActive(false);    
        }
    }

    public void Damage(PlayerStatus playerStatus)
    {
        if (enemyCombat.InBlock)
        {
            life -= playerStatus.DamageBlock;
        }
        else
        {
            life -= playerStatus.DamageHit;
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
}
