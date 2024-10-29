using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuVideoPlayer : MonoBehaviour
{
   [SerializeField] VideoPlayer videoPlayer;

    [SerializeField] VideoClip[] clips;

    [SerializeField] Slider volumeSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        StartingVideoRandomise();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.SetDirectAudioVolume(0, volumeSlider.value);
    }

    void StartingVideoRandomise()
    {
        int randome = Random.Range(0, clips.Length);
        videoPlayer.clip = clips[randome];
    }

}
