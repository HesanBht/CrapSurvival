using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerObject;

    [SerializeField] float Xmin = 15;
    [SerializeField] float Xmax = 20;
    [SerializeField] float Ymin = 15;
    [SerializeField] float Ymax = 20;

    [SerializeField] GameObject[] runes;

    [SerializeField] float spawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<Tag_player>().gameObject;
        StartCoroutine(SpawningRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawningRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnRune();
        }
    }

    void SpawnRune()
    {
        int xboundry = UnityEngine.Random.Range(0, 2);
        float x = 0;
        float y = 0;
        if (xboundry < 1)
        {
            x = UnityEngine.Random.Range
            (playerObject.transform.position.x + Xmin, playerObject.transform.position.x + Xmax);
            y = UnityEngine.Random.Range
            (playerObject.transform.position.y, playerObject.transform.position.y + Ymax);
        }
        else
        {
            y = UnityEngine.Random.Range
            (playerObject.transform.position.y + Ymin, playerObject.transform.position.y + Ymax);
            x = UnityEngine.Random.Range
            (playerObject.transform.position.x, playerObject.transform.position.x + Xmax);
        }

        int garinX = UnityEngine.Random.Range(0, 2);

        int garinY = UnityEngine.Random.Range(0, 2);

        if (garinX < 1)
        {

            float offset1 = Mathf.Abs(playerObject.transform.position.x - x);
            x = playerObject.transform.position.x - offset1;
        }
        if (garinY < 1)
        {
            float offset2 = Mathf.Abs(playerObject.transform.position.y - y);
            y = playerObject.transform.position.y - offset2;
        }

        GameObject _rune = runes[Random.Range(0, runes.Length)];

        Vector2 pos1 = new Vector2(x, y);
        Instantiate(_rune, pos1, _rune.transform.rotation);
      //  print("boundry : " + xboundry + "garinX : " + garinX + "  garinY : " + garinY + "enemypos :" + pos1 + "pos : " + playerObject.transform.position);

    }

}
