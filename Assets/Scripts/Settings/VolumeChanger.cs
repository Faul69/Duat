using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField]private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
#if UNITY_WEBGL && !UNITY_EDITOR
        _slider.value = Agava.YandexGames.Progress.Instance.Info.VolumeValue;
        AudioListener.volume = Agava.YandexGames.Progress.Instance.Info.VolumeValue;
#endif
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void SaveSettings()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Progress.Instance.Save();
#endif
    }

    private void ChangeVolume(float value)
    {
        AudioListener.volume = value;
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Progress.Instance.Info.VolumeValue = value;
#endif
    }
}
