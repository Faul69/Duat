using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSprite : MonoBehaviour
{
    [SerializeField] private List<Sprite> _icons;
    [SerializeField] private Image _volumeIcon;

    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _volumeIcon.sprite = _icons[0];
        _slider.onValueChanged.AddListener(ChangeIcon);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeIcon);
    }

    private void ChangeIcon(float value)
    {
        if (value > 0)
            _volumeIcon.sprite = _icons[0];
        else
            _volumeIcon.sprite = _icons[1];

    }
}
