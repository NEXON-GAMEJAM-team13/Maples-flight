using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip BGMClip;
    private AudioListener audioListener;

    private void Awake()
    {

        audioSource.clip = BGMClip;
        audioSource.loop = true;


    }

    public void OnBGMClicked()
    {
        if (SoundManager.Instance.toggleActive[0])
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }

    }





}
