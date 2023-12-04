using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PositionRebuilder : MonoBehaviour
{
    private List<SoulMover> _souls;
    private float _currentDelay;

    private void OnEnable()
    {
        _souls = new List<SoulMover>();
    }

    public void TakeSoulForRebuild(SoulMover mover)
    {
        _souls.Add(mover);
    }

    public async Task StartAlign(float firstTime)
    {
        var currentTime = _currentDelay * _souls.Count + firstTime;

        foreach (SoulMover soul in _souls)
        {
            soul.Align(currentTime);
            currentTime -= _currentDelay;
        }

        _souls.Clear();
        await Task.Yield();
    }

    public void Init(float delay)
    {
        _currentDelay = delay;
    }
}
