using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private WinPanelView _winPanel;
    [SerializeField] private AudioLiblary _soundLibrary;

    public void EndWin()
    {
        _soundLibrary.PlayWinSound();
        StopAll();
        _winPanel.ViewWinPanel();
    }

    private void StopAll()
    {
        Time.timeScale = 0f;
    }
}
