using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class EnemyIDGenerator : MonoBehaviour
{
    [SerializeField] int lastIDAssigner = 0;



    public int GenerateAndGetID()
    {
        int _id = lastIDAssigner++;
        return _id;
    }
}
