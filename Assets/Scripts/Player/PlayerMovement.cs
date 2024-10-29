using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        moveSpeed = playerConfigHolder.moveSpeed;
    }
    #endregion




    [SerializeField] float moveSpeed = 1f;

    [SerializeField] PlayerInputManager playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        transform.position += playerInputManager.GetMoveVectorNormalized() * moveSpeed * Time.deltaTime;
    }
}
