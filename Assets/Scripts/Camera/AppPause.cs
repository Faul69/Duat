using UnityEngine;

public class AppPause : MonoBehaviour
{
    private void OnEnable()
    {
        Agava.WebUtility.WebApplication.InBackgroundChangeEvent += StopGame;
    }

    private void OnDisable()
    {
        Agava.WebUtility.WebApplication.InBackgroundChangeEvent -= StopGame;
    }

    public void StopGame(bool isStop)
    {
        Time.timeScale = isStop ? 0 : 1;
    }

    private void OnApplicationFocus(bool isAppFocus)
    {
        Time.timeScale = isAppFocus ? 1 : 0;
    }
}
