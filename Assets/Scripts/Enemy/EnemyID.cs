using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyID : MonoBehaviour
{
   [SerializeField] int id = 0;

    public void SetId(int _id)
    {
        id = _id;
    }
    public int GetId()
    {
        return id;
    }

  
}
