using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Agava.WebUtility.Samples
{
    public class AudioOffer : MonoBehaviour
    {
        private float _volumeMusic = 0.2f;

        public static AudioOffer VolumeOffer;

        private void OnEnable()
        {
            transform.parent = null;
            VolumeOffer = this;

            WebApplication.InBackgroundChangeEvent += ChangeMusicVolume;
#if UNITY_WEBGL && !UNITY_EDITOR
            _volumeMusic = Agava.YandexGames.Progress.Instance.Info.VolumeValue;
            AudioListener.volume = Agava.YandexGames.Progress.Instance.Info.VolumeValue;
#endif
        }

        private void Start()
        {
            ChangeMusicVolume(false);
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= ChangeMusicVolume;
        }

        private void OnApplicationFocus(bool isAppFocus)
        {
            AudioListener.pause = !isAppFocus;
            AudioListener.volume = !isAppFocus ? 0f : _volumeMusic;
        }

        public void ChangeMusicVolume(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : _volumeMusic;
        }
    }
}
