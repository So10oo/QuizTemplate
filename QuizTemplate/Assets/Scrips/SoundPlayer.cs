using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Image image;

    [SerializeField] private Sprite _spriteOn;
    [SerializeField] private Sprite _spriteOff;

    [SerializeField] private AudioClip[] clips;

    private void Awake()
    {
        image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();   
        StartCoroutine(OnAudioClipEnd());
    }

    private void OnValidate()
    {
        var image = GetComponent<Image>();
        image.sprite = _spriteOn;
        //foreach (var clip in clips)
        //{
        //    if (clip == null)
        //        clips.toL
        //}
    }

    private IEnumerator OnAudioClipEnd()
    {
        if (_audioSource.clip == null) 
        {
            _audioSource.clip = clips[0];
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
        }
        
        while (true)
        {
            var index = Array.IndexOf(clips, _audioSource.clip) + 1;
            if (index != clips.Length)
                _audioSource.clip = clips[index];
            else
                _audioSource.clip = clips[0];
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
        }

    }
    
    public void ChangeVolumeSound()
    {
        if (_audioSource.mute)
        {
            image.sprite = _spriteOn;
            _audioSource.mute = false;  
        }
        else 
        {
            image.sprite = _spriteOff;
            _audioSource.mute = true;
        }
    }

}
