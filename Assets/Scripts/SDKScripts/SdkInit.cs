using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Agava.YandexGames.Samples
{

    public class SdkInit : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine( YandexGamesSdk.Initialize(Load));
        }

        private void Load()
        {
            PlayerAccount.GetCloudSaveData(Progress.Instance.GetCloudInfo);

            if (YandexGamesSdk.IsInitialized)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
