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

    [SerializeField]
    Sprite OnSprite;

    [SerializeField] 
    Sprite OffSprite;
    [SerializeField]
    GameObject[] sfxIcon= new GameObject[2];

    [SerializeField]
    GameObject[] bgmIcon= new GameObject[2];

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
        audiosource=GetComponent<AudioSource>();
        audiosource.loop=true;
        bgmOn=false;
        sfxOn=true;
        UpdateBtns(bgmToggle, bgmOn);
        UpdateIcons(bgmIcon, bgmOn);
        UpdateBtns(sfxToggle, sfxOn);
        UpdateIcons(sfxIcon, sfxOn);

    }


    public void UpdateBtns(GameObject[] btns, bool isActive){
        for(int i=0;i<2;i++){
            float togglePosX=btns[i].transform.localPosition.x;
            if(isActive) togglePosX=190;
            else togglePosX=99;
             btns[i].transform.localPosition 
        = new Vector3(togglePosX, btns[i].transform.localPosition.y, btns[i].transform.localPosition.z); 
        }
    }

    public void UpdateIcons(GameObject[] Icons, bool isActive){
        for(int i=0;i<2;i++){
            if(isActive) Icons[i].GetComponent<Image>().sprite=OnSprite;
            else Icons[i].GetComponent<Image>().sprite=OffSprite;

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
        UpdateBtns(bgmToggle, bgmOn);
        UpdateIcons(bgmIcon, bgmOn);

    }

     public void SFXClicked(){
        if(sfxOn){
            sfxOn=false;
        }
        else{
            sfxOn=true;
        }
        UpdateBtns(sfxToggle, sfxOn);
        UpdateIcons(sfxIcon, sfxOn);
    }
    
 



}