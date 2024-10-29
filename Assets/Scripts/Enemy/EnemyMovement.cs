using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Configer
    [SerializeField] EnemyConfigHolder enemyConfigHolder;
    void StartingConfigApplication()
    {
        defultMoveSpeed = enemyConfigHolder.defultMoveSpeed;

    }
    #endregion


     float defultMoveSpeed = 4f;
     float moveSpeed = 4f;
    [SerializeField] GameObject playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();
        moveSpeed = defultMoveSpeed;

        playerObject = FindObjectOfType<Tag_player>().GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, moveSpeed * Time.deltaTime);
    
    }
   

    public void ApplySlow(int slowPercentage)
    {
        moveSpeed = defultMoveSpeed - (defultMoveSpeed * slowPercentage / 100);
    }
    public void EndSlow()
    {
        moveSpeed = defultMoveSpeed;
    }
}
