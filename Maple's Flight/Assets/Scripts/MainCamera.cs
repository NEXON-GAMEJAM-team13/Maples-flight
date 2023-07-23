using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip BGMClip;
    private AudioListener audioListener;
    [SerializeField] SoundManager soundManager;
    private void Awake()
    {

        audioSource.clip = BGMClip;
        audioSource.loop = true;


    }
    public void Start()
    {
        audioSource.clip = BGMClip;
        audioSource.volume = 0;
    }

    public void Update()
    {
        if (soundManager.soundPlaying)
        {

            audioSource.clip = BGMClip;
            audioSource.volume = 1;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

    }
    // public void OnBGMClicked()
    // {
    //     if (SoundManager.Instance.toggleActive[0])
    //     {
    //         AudioListener.volume = 1;
    //     }
    //     else
    //     {
    //         AudioListener.volume = 0;
    //     }

    // }





}