using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDesctruct());
    }

    IEnumerator SelfDesctruct()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
