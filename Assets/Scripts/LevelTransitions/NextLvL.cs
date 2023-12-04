using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Plugins.Audio.Core;

namespace Agava.YandexGames.Samples
{

    public class NextLvL : MonoBehaviour
    {
        [SerializeField] private SourceAudio _magnitola;

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

        public void IncreaseProgress()
        {
            if (Agava.YandexGames.Progress.Instance.Info.LevelUnlock < SceneManager.GetActiveScene().buildIndex)
            {
                Agava.YandexGames.Progress.Instance.Info.LevelUnlock++;
                Agava.YandexGames.Progress.Instance.Save();
            }
        }

        private void ShowAd()
        {
            _magnitola.Mute = true;

#if UNITY_WEBGL && !UNITY_EDITOR
            InterstitialAd.Show(LoadOnOpenAd, OnCloseAd, LoadOnErrorAd, LoadOnOfflineAd);
#endif

#if !UNITY_WEBGL && UNITY_EDITOR
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
#endif
        }

        private void LoadOnOpenAd()
        {
            IncreaseProgress();
        }

        private void OnCloseAd(bool ended)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _isShown = ended;
        }

        private void LoadOnErrorAd(string error)
        {
            if (_isShown)
                return;

            Debug.Log(error);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void LoadOnOfflineAd()
        {
            if (_isShown)
                return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
