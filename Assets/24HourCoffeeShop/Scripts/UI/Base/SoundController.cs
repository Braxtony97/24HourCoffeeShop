using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _backgroundMusicSource;

    private readonly Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    [Inject]
    public void Construct(DiContainer container)
    {
        LoadAudioClips();
        
    }

    private void LoadAudioClips()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (var clip in clips)
        {
            _audioClips[clip.name] = clip;
        }
    }

    public void PlaySound(GameEnums.Sounds sound, bool isMainBackground = false)
    {
        string musicName = sound.ToString();

        if (_audioClips.TryGetValue(musicName, out AudioClip clip))
        {
            if (!isMainBackground)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
            else
            {
                _backgroundMusicSource.clip = clip;
                _backgroundMusicSource.Play();
            }
            
        }
    }
}
