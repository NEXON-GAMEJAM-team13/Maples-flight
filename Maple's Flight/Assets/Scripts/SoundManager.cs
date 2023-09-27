using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public bool bgmOn;
    public bool sfxOn;
    AudioSource audiosource;

    [SerializeField]
    GameObject[] bgmToggle = new GameObject[2];
    
    [SerializeField]
    GameObject[] sfxToggle= new GameObject[2];


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
        audiosource.loop=true;
        bgmOn=false;
        sfxOn=true;
        UpdateBGMBtns(bgmOn);
        UpdateSFXBtns(sfxOn);
    }



    public void UpdateBGMBtns(bool isActive){
        float togglePos=0;
        for(int i=0; i<2; i++){
            if(isActive) togglePos=190;
            else togglePos=100;
        bgmToggle[i].transform.localPosition 
        = new Vector3(togglePos, bgmToggle[i].transform.localPosition.y, bgmToggle[i].transform.localPosition.z); 
        }
    }

    public void UpdateSFXBtns(bool isActive){
        float togglePos=0;
        for(int i=0; i<2; i++){
            if(isActive) togglePos=190;
            else togglePos=100;
        sfxToggle[i].transform.localPosition 
        = new Vector3(togglePos, sfxToggle[i].transform.localPosition.y, sfxToggle[i].transform.localPosition.z); 
        }
    }


    public void BGMClicked(){
        if(bgmOn){
            bgmOn=false;
            audiosource.Stop();
        }
        else{
            bgmOn=true;
            audiosource.Play();
        }
        UpdateBGMBtns(bgmOn);

    }

     public void SFXClicked(){
        if(sfxOn){
            sfxOn=false;
        }
        else{
            sfxOn=true;
        }
        UpdateSFXBtns(sfxOn);
    }
    
 



}