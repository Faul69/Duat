using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class SwitchPanels : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsEnable;
    [SerializeField] private List<GameObject> _objectsDisable;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        ChangeEnable(_objectsEnable, true);
        ChangeEnable(_objectsDisable, false);
    }

    private void ChangeEnable(List<GameObject> list, bool changeTo)
    {
        if (list == null)
            return;

        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(changeTo);
        }
    }
}

