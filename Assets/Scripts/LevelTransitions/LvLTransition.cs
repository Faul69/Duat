using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Agava.YandexGames.Samples
{
    [RequireComponent(typeof(Button))]
    public class LvLTransition : MonoBehaviour
    {
        [SerializeField] private int _numberOfScene;

        private Button _button;
        private bool _isShown = false;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ShowAd);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowAd);
        }

        private void ShowAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            AudioListener.volume = 0;
            InterstitialAd.Show(LoadOnOpenAd, OnCloseAd, LoadOnErrorAd, LoadOnOfflineAd);
#endif

#if !UNITY_WEBGL && UNITY_EDITOR
            SceneManager.LoadScene(_numberOfScene);
#endif
        }

        private void LoadOnOpenAd()
        {
        }

        private void OnCloseAd(bool ended)
        {
            AudioListener.volume = Agava.YandexGames.Progress.Instance.Info.VolumeValue;
            SceneManager.LoadScene(_numberOfScene);
            _isShown = ended;
        }

        private void LoadOnErrorAd(string error)
        {
            if (_isShown)
                return;

            Debug.Log(error);
            SceneManager.LoadScene(_numberOfScene);
        }

        private void LoadOnOfflineAd()
        {
            if (_isShown)
                return;

            SceneManager.LoadScene(_numberOfScene);
        }
    }
}
