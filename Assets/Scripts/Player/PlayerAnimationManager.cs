using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
   [SerializeField] PlayerInputManager playerInputManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputManager.GetMoveVectorNormalized() != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
            GetComponent<Animator>().SetBool("isMoving", false);
    }
}
