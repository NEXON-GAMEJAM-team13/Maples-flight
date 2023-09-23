using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    AudioSource audiosource;
    public bool sfxOn;
    // [SerializeField]
    // private GameObject settingPopup;
    public static SoundManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    private void Awake(){
        if(Instance != this) Destroy(gameObject);
       // settingPopup=GameObject.FindObjectsOfTypeAll("SettingPopup");
        audiosource=GetComponent<AudioSource>();
        sfxOn=true;
    }


    public void BGMOn(){
        audiosource.loop=true;
        audiosource.Play();
    }   
    public void BGMOff(){
        audiosource.loop=false;
        audiosource.Stop();
    }
    
    

    

    
 



}