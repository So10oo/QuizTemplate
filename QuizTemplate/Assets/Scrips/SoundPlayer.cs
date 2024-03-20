using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] Sprite _spriteOn;
    [SerializeField] Sprite _spriteOff;
    [SerializeField] AudioClip[] clips;

    Image image;
    AudioSource _audioSource;
    float timeClip = 0;

    private void Awake()
    {
        image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(AudioClipPlay());
    }

    private void OnValidate()
    {
        var image = GetComponent<Image>();
        image.sprite = _spriteOn;
    }

    private IEnumerator AudioClipPlay()
    {
        int index;
        while (true)
        {
            index = Array.IndexOf(clips, _audioSource.clip) + 1;
            if (index != clips.Length)
                _audioSource.clip = clips[index];
            else
                _audioSource.clip = clips.First();
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
        }
    }

    public void ChangeVolumeSound()
    {
        if (_audioSource.mute)
            image.sprite = _spriteOn;
        else
            image.sprite = _spriteOff;
        _audioSource.mute = !_audioSource.mute;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.pause = silence;

        if (silence)
            timeClip = _audioSource.time;
        else
            _audioSource.time = timeClip;
    }

      
   
}
