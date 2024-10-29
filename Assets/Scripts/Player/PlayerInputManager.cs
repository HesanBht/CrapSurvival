using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] KeyCode moveRightKey = KeyCode.D;
    [SerializeField] KeyCode moveUpKey = KeyCode.W;
    [SerializeField] KeyCode moveDownKey = KeyCode.S;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 GetMoveVectorNormalized()
    {
        Vector3 normalizedMoveVector;
        float Xval = 0;
        float Yval = 0;

        if (Input.GetKey(moveLeftKey))
        {
            Xval = -1;
        }
        else if (Input.GetKey(moveRightKey))
        {
            Xval = 1;
        }
        else
        {
            Xval = 0;
        }

        if (Input.GetKey(moveUpKey))
        {
            Yval = 1;
        }
        else if (Input.GetKey(moveDownKey))
        {
            Yval = -1;
        }
        else
        {
            Yval = 0;
        }

        normalizedMoveVector = new Vector3(Xval, Yval, 0).normalized;

        return normalizedMoveVector;
    }
}
