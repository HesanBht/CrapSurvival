using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject groundTile;

    [SerializeField] int offset =8;
   
    [SerializeField] int num = 50;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < num; x++)
        {
            for (int y = 0; y < num; y++)
            {
                GameObject _ins1 = Instantiate(groundTile, transform);
                _ins1.transform.position = Vector3.zero + new Vector3(offset * x, offset * y, 0f);


            }
        }
        transform.position = new Vector3(-offset * (num / 2), -offset * (num / 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
