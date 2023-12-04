using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySoulsEnd : MonoBehaviour
{
    private const int BugInaccuracy = 1;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Worm _worm;
    [SerializeField] private LoosePanelView _loosePanel;

    private int _counter;

    private void Awake()
    {
        transform.position = Vector3.zero;
        _counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<SoulActions>(out _))
        {
            CountBombedSouls();
        }
    }

    private void CountBombedSouls()
    {
        _counter++;

        if (_counter >= _spawner.CountSouls - BugInaccuracy && _worm.CurrentHealth > 0)
        {
            Time.timeScale = 0f;
            _loosePanel.ViewEndPanel();
        }
    }
}
