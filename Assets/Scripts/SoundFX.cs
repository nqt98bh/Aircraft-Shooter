using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX Instance;
    public  bool isBackgroundSoundPlaying = false;
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] AudioSource soundFX;
    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   // public List<AudioSource>  audioSource = new List<AudioSource> { };

    [SerializeField]private AudioClipName[] audioClipName = new AudioClipName[5];

    [System.Serializable]
    class AudioClipName
    {
        public SoundType soundtype;
        public AudioClip audioClip;
    }
    
    public void PlaySoundFX(SoundType soundtype) 
    {

        //AudioSource audioSource = null;
        ////audioSource = GetAudioSource();
        ////if (audioSource == null)
        ////{
        ////    AddNewAudioSource(GetAudioClip(soundtype));
        ////    return;
        ////}
        ////if (isBackgroundSoundPlaying)
        ////{
        ////    audioSource.Stop();
        ////    isBackgroundSoundPlaying = false;
        ////}
        soundFX.PlayOneShot(GetAudioClip(soundtype));
       
        

    }
    private AudioClip GetAudioClip(SoundType soundtype) //lay loai sound
    {
        AudioClip audioclip = null;
        for (int i = 0; i < audioClipName.Length; i++)
        {
            if (audioClipName[i].soundtype == soundtype)
            {
                audioclip = audioClipName[i].audioClip;
                break;
            }
        }
        return audioclip;
    }
    public void PlayBackgroundMusic()
    {
        backGroundMusic.clip = GetAudioClip(SoundType.BackgroundMusic);
        backGroundMusic.loop = true;
        backGroundMusic.Play();
    }
    //private AudioSource GetAudioSource() //tim audiosound chua su dung
    //{
    //    for (int i = 0; i < audioSource.Count; i++)
    //    {
    //        if (!audioSource[i].isPlaying)
    //        {
    //            audioSource[i].Play();
    //            return audioSource[i];
    //        }
    //    }
    //    return null;
    //}

    //void AddNewAudioSource(AudioClip audioclip)
    //{
    //    AudioSource audio = gameObject.AddComponent<AudioSource>();
    //    audioSource.Add(audio);
    //    audio.clip = audioclip;
    //    audio.Play();
    //}
}
public enum SoundType
{
    Explosion,
    Shot,
    PlayerFire,
    PlayerDie,
    Menu,
    BackgroundMusic,
}



