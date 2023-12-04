using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLvLDisable : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;

    private int _levelProgress;

    private void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        _levelProgress = Agava.YandexGames.Progress.Instance.Info.LevelUnlock;
        DisableButtons();
#endif
    }

    private void DisableButtons()
    {
        int i = 0;

        foreach  (Button button in _buttons)
        {
            if (i < _levelProgress)
                button.interactable = true;
            else
                button.interactable = false;

            i++;
        }
    }
}
