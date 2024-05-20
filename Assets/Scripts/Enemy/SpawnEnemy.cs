using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;

    [SerializeField] private GameObject[] spawn;

    [SerializeField] private GameObject enemy;

    private bool canSpawn = true;
    private int enemyMax = 2;
    private int enemyQ;

    private float cooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
            Instance = this;

        enemyQ = enemyMax;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (canSpawn)
        {
            canSpawn = false;

            StartCoroutine(SpawnCooldown());
        }

        if (enemyQ <= 0)
        {
            enemyMax += 2;
            enemyQ = enemyMax;
            canSpawn = true;
        }

        switch(enemyQ) 
        {
            case 12:
                cooldown = 0.8f;
                break;
            case 20:
                cooldown = 0.6f;
                break;
            case 30:
                cooldown = 0.4f;
                break;
            case 50:
                cooldown = 0.2f;
                break;
        }
    }

    IEnumerator SpawnCooldown()
    {
        for (int i = 0; i < enemyMax; i++)
        {
            yield return new WaitForSeconds(cooldown);

            Random.InitState((int)System.DateTime.Now.Ticks);

            int randomPos = Random.Range(0, 2);

            GameObject enemyObj = Instantiate(enemy, spawn[randomPos].transform.position, spawn[randomPos].transform.rotation);

            if (randomPos == 0)
            {
                enemyObj.transform.localScale = new Vector3(-1, 1, 1);
                enemyObj.GetComponent<EnemyCombat>().DirectionRight = false;
            }
            else
            {
                enemyObj.transform.localScale = new Vector3(1, 1, 1);
                enemyObj.GetComponent<EnemyCombat>().DirectionRight = true;
            }
        }
    }

    public int EnemyQ
    {
        get { return enemyQ; }
        set { enemyQ = value; }
    }
}
