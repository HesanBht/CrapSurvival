using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    [SerializeField] float scollSpeed = 1;
    float offset = 0;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        offset += (Time.deltaTime * scollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
