using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyOrderEvent : MonoBehaviour
{
    public static event Action<GameObject> onEnemyKillOrder;
  


    public void GiveEnemyKillOrder(GameObject _enemy)
    {
        if (_enemy == null) return;
        onEnemyKillOrder?.Invoke(_enemy);
    }
}
