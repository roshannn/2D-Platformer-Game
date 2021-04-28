using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    

    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public SoundType[] sounds;
    
    public bool isMute = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Start()
    {
        
        PlayMusic(global::Sounds.Music);
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip!= null)
        {
            soundEffect.PlayOneShot(clip);
            Debug.Log("Sound being played is:" + clip);
        }
        else
        {
            Debug.LogError("Sound not found");
        }
        
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip!= null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
            Debug.Log("Sound being played is:" + clip);
        }
        else
        {
            Debug.LogError("Sound not found");
        }
        
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
        if(item != null)
        {
            return item.soundClip;
        }
        else
        {
            return null;
        }
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    
    Reset,
    Back,
    Music,
    LevelLocked,
    StartGame,
    LevelSelect,
    PlayerLeftFoot,
    PlayerRightFoot,
    PlayerJump,
    PlayerDeath,
    LevelComplete,
    LevelStart,
    PlayerJumpLand,
    CoinCollect

}