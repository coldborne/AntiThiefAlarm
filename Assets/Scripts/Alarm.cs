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
    private Coroutine _fadeCoroutine;
    private float _minVolume;

    private void Awake()
    {
        _minVolume = 0.0f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
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
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        StartFade(_maxVolume);
    }

    private void TurnOff()
    {
        StartFade(_minVolume);
    }

    private void StartFade(float targetVolume)
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(FadeVolume(targetVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        float startVolume = _audioSource.volume;
        float time = 0.0f;

        while (time < _soundVolumeChangeDuration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / _soundVolumeChangeDuration);
            yield return null;
        }

        _audioSource.volume = targetVolume;

        if (Mathf.Approximately(targetVolume, _minVolume))
        {
            _audioSource.Stop();
        }
    }
}