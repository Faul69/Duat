using System.Collections.Generic;
using UnityEngine;

public class LooseGame : MonoBehaviour
{
    [SerializeField] private LoosePanelView _endPanel;
    [SerializeField] private AudioLiblary _soundLiblary;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoulActions>(out _))
        {
            _soundLiblary.PlayLooseSound();
            Time.timeScale = 0f;
            _endPanel.ViewEndPanel();
        }
    }
}
