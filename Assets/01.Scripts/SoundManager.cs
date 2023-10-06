using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _musicPlayList;
    private AudioSource _myAudio;
    
    private bool _isPlaying;
    private float _currentPlayTime; //현재 재생시간
    [SerializeField]
    private float _durationTime; //임시 재생을 할 시간

    private static SoundManager _soundInstance; //SoundManager class를 인스턴스화 시킴

    public static SoundManager soundInstance
    {
        get => _soundInstance;
    }

    private void Awake()
    {
        if (_soundInstance == null)
            _soundInstance = this;
        _myAudio = GetComponent<AudioSource>();
        _isPlaying = false;
        _currentPlayTime = 0.0f;
    }

    private void Update()
    {
        if (_isPlaying) 
        {
            _currentPlayTime += Time.deltaTime;

            if( _currentPlayTime > _durationTime ) 
            {
                StopSound();
                _currentPlayTime = 0.0f;
            }
        }
    }

    public void PlaySound(int idx)
    {
        StopSound();
        _myAudio.PlayOneShot(_musicPlayList[idx]);
        _isPlaying = true;
    }

    public void StopSound()
    {
        _myAudio.Stop();
        _isPlaying = false;
    }

}
