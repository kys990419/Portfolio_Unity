using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{
    public AudioSource bgSound;
    public static SoundManager2 instace;
    public float sound = 0.5f;
    private void Start()
    {
        sound = 0.5f;
    }
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(instace);
        }
        else Destroy(gameObject);
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = sound;
        bgSound.Play();
    }
    public void BgSoundStop(AudioClip clip)
    {
        bgSound.Stop();
    }
    public void SetBgVolume(float volum)
    {
        sound = volum;
    }
}