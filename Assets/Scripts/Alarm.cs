using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Door _door;

    [Header("Параметры звука")] [SerializeField, Range(0.0f, 1.0f)]
    private float _maxVolume;

    [SerializeField] private float _soundVolumeChangeDuration;

    private AudioSource _audioSource;
    private float _minVolume;

    private void Awake()
    {
        _minVolume = 0.0f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.0f;
        _audioSource.loop = true;
    }

    private void OnEnable()
    {
        _door.Opened += TurnOn;
        _door.Closed += TurnOff;
    }

    private void OnDisable()
    {
        _door.Opened -= TurnOn;
        _door.Closed -= TurnOff;
    }

    private void TurnOn()
    {
        _audioSource.Play();
        StartCoroutine(FadeIn(_soundVolumeChangeDuration, _maxVolume));
    }

    private void TurnOff()
    {
        StartCoroutine(FadeOut(_soundVolumeChangeDuration));
    }

    private IEnumerator FadeIn(float duration, float targetVolume)
    {
        float startVolume = _audioSource.volume;
        float time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        _audioSource.volume = targetVolume;
    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = _audioSource.volume;
        float time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, _minVolume, time / duration);
            yield return null;
        }

        _audioSource.volume = _minVolume;
        _audioSource.Stop();
    }
}