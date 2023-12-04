using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaneCreator : MonoBehaviour
{
    [SerializeField] private float _delayOnStart;

    private readonly List<SoulBuilder> _poolSouls = new();
    private WaitForSeconds _delay;

    public float Delay => _delayOnStart;

    private void Awake()
    {
        _delay = new WaitForSeconds( _delayOnStart);
    }

    public IEnumerator RunSoulWithDelay()
    {
        for (int i = 0; i < _poolSouls.Count; i++)
        {
            var action = _poolSouls[i].GetComponent<SoulActions>();
            yield return _delay;
            action.transform.position = gameObject.transform.position;
            action.StartMove();
        }
    }

    public void AddSoulInPool(SoulBuilder soul)
    {
        _poolSouls.Add(soul);
    }
}
