using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (Agava.YandexGames.Progress.Instance.Info.IsTutorial)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
            gameObject.SetActive(false);
#endif
    }

    public void EndTutorial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Progress.Instance.Info.IsTutorial = false;
        Agava.YandexGames.Progress.Instance.Save();
#endif
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
