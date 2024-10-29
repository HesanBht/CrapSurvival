using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class Golem : MonoBehaviour
{

    #region Configer
    [SerializeField] EnemyConfigHolder enemyConfigHolder;
    void StartingConfigApplication()
    {
        maxSplit = enemyConfigHolder.maxSplit;
        sizeSplitAmount = enemyConfigHolder.sizeSplitAmount;
    }
    #endregion



    [SerializeField] GameObject golemPrefab;

     int maxSplit = 2;
     float sizeSplitAmount = 1.7f;

    [SerializeField] int timesSplited = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyHealth>().SetHealth(GetComponent<EnemyHealth>().GetHealth() / (timesSplited + 1));
        // +1 because split starts at 0
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnDestroy()
    {

    }



    public void Split()
    {
        if (timesSplited >= maxSplit) return;

        GameObject _isntance1 = Instantiate(golemPrefab, transform.position + new Vector3(1, 0), transform.rotation);
        GameObject _isntance2 = Instantiate(golemPrefab, transform.position + new Vector3(-1, 0), transform.rotation);

        _isntance1.GetComponent<Golem>().AddSplitTime(timesSplited);
        _isntance2.GetComponent<Golem>().AddSplitTime(timesSplited);

        _isntance1.SetActive(true);
        _isntance2.SetActive(true);
    }


    void AddSplitTime(int currentSplit)
    {
        timesSplited = currentSplit + 1;

        transform.localScale = new Vector3(transform.localScale.x / sizeSplitAmount, transform.localScale.y / sizeSplitAmount,
            transform.localScale.z);
    }

   public int GetTimeSplited()
    {
        return timesSplited;
    }
}
