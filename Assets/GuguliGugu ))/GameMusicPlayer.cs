using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicPlayer : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = volumeSlider.value;
    }
}
