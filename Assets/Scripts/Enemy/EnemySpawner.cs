using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float enemySpawnWaitTime = 2f;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject enemyObject;
    [SerializeField] float Xmin = 15;
    [SerializeField] float Xmax = 20;
    [SerializeField] float Ymin = 15;
    [SerializeField] float Ymax = 20;


    int currentplayerlvl = 0;

    EnemyIDGenerator enemyIDGenerator;

    public static event Action<GameObject> onEnemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        enemyIDGenerator = FindObjectOfType<EnemyIDGenerator>();
        StartCoroutine(Spawnroutine());
        PlayerXp.onLevelup+= whenlvlup;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnDestroy()
    {
        PlayerXp.onLevelup -= whenlvlup;
    }
    void EnemySpawn()
    {
        int xboundry = UnityEngine.Random.Range(0,2);
        float x = 0;
        float y = 0;
        if (xboundry < 1)
        {
            //float pox = playerObject.transform.position.x / MathF.Abs(playerObject.transform.position.x);
            x = UnityEngine.Random.Range
            (playerObject.transform.position.x +Xmin, playerObject.transform.position.x + Xmax);
            y= UnityEngine.Random.Range 
            (playerObject.transform.position.y, playerObject.transform.position.y+Ymax);
        }
        else
        {
            //float pox = playerObject.transform.position.y / MathF.Abs(playerObject.transform.position.y);
            y = UnityEngine.Random.Range
            (playerObject.transform.position.y + Ymin, playerObject.transform.position.y + Ymax);
            x= UnityEngine.Random.Range 
            (playerObject.transform.position.x, playerObject.transform.position.x+Xmax);
        }
        
        int garinX = UnityEngine.Random.Range(0,2);

        int garinY = UnityEngine.Random.Range(0,2);

        if (garinX<1)
        {
            
            float offset1 = Mathf.Abs(playerObject.transform.position.x - x);
            x = playerObject.transform.position.x - offset1;
        }
        if (garinY<1)
        {
            float offset2 = Mathf.Abs(playerObject.transform.position.y - y);
            y = playerObject.transform.position.y - offset2;
        }
        Vector2 pos1 = new Vector2(x,y);
        GameObject enemyInstance = Instantiate(enemyObject, pos1, enemyObject.transform.rotation);
        print("boundry : "+xboundry+"garinX : "+ garinX+"  garinY : "+garinY+"enemypos :"+pos1+"pos : " + playerObject.transform.position);

        AssingIdToEnemy(enemyInstance);
        onEnemySpawn?.Invoke(enemyInstance);

    }

    void NewEnemySpawn()
    {
        
    }
    IEnumerator Spawnroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnWaitTime);
            EnemySpawn();

        }
        
    }

    void AssingIdToEnemy(GameObject enemyObject)
    {
        if (enemyObject.GetComponent<EnemyID>() == null) return;

        int id = enemyIDGenerator.GenerateAndGetID();
        enemyObject.GetComponent<EnemyID>().SetId(id);
        enemyObject.name = "Enemy" + id;
    }
    void whenlvlup(int lvl)
    {
        currentplayerlvl = lvl;
        enemySpawnWaitTime = enemySpawnWaitTime / 10 * 9;
    }
}
