using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource sfxAudioSource;

    // I believe letting the AudioManager take care of every audioclip makes it easier for designers
    [field: SerializeField] public AudioClip equipItemSFX, spendCoinsSFX;


    void Awake()
    {
        Instance = this;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }
}
