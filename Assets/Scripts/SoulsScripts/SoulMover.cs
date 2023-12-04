using UnityEngine;
using DG.Tweening;
using System;
using System.Threading.Tasks;

public class SoulMover : MonoBehaviour
{
    private const float NormalTimeScale = 1f;
    private const float TimeMoveTo = 0.5f;

    private Tween _tween;
    private PositionRebuilder _rebuilder;

    public event Action ResumeMove;
    public event Action BackMove;
    public event Action<float> MoveOver;
    public event Action<float> Accelerete;

    private void OnDisable()
    {
        _tween.Kill(true);
    }

    public void Pause()
    {
        _tween.Pause();
    }

    public void Align(float elapsedTime)
    {
        _tween.fullPosition = elapsedTime;
        _tween.PlayForward();
        _tween.timeScale = NormalTimeScale;
    }

    public async void MoveForNewSoul(float multiplayer)
    {
        var endTime = Time.time + TimeMoveTo;
        var endValue = NormalTimeScale * multiplayer;
        MoveOver.Invoke(multiplayer);
        _tween.timeScale = endValue;

        while (Time.time < endTime)
        {
            await Task.Yield();
        }

        _tween.timeScale = NormalTimeScale;
    }

    public void Accel(float multiplier)
    {
        Accelerete.Invoke(multiplier);
        _tween.timeScale += multiplier;
    }

    public void PlayBackward(bool doSelf = true)
    {
        BackMove?.Invoke();
        if (doSelf)
        {
            _rebuilder.TakeSoulForRebuild(this);
            _tween?.PlayBackwards();
        }
    }

    public void PlayForward(bool doSelf = true)
    {
        ResumeMove?.Invoke();
        if (doSelf)
        {
            _tween?.PlayForward();
            _tween.timeScale = NormalTimeScale;
        }
    }

    public void MoveToPlayer(Vector3 playerPosition)
    {
        _tween.Pause();
        transform.DOMove(playerPosition, TimeMoveTo);
    }

    public async Task MoveToChane(Vector3 position)
    {
        await transform.DOMove(position, TimeMoveTo).SetEase(Ease.Linear).AsyncWaitForCompletion();
    }

    public float SetTweenTime(float needTime)
    {
        _tween.fullPosition = needTime + TimeMoveTo;
        _tween.PlayForward();
        return _tween.fullPosition;
    }

    public float GetElapsed()
    {
        return _tween.Elapsed();
    }

    public void Init(Transform path, PositionRebuilder rebuilder)
    {
        _rebuilder = rebuilder;

        if (path == null)
            return;

        Vector3[] points = new Vector3[path.childCount];

        for (int i = 0; i < path.childCount; i++)
        {
            points[i] = path.GetChild(i).position;
        }

        _tween = transform.DOPath(points, 150, PathType.CatmullRom).SetLookAt(0.01f);
        _tween.SetEase(Ease.Linear);
        _tween.SetAutoKill(false);
        _tween.Pause();
    }

    public void StartAnimation(float multiplayer = 1f)
    {
        _tween.Play();
        float endValue = NormalTimeScale * multiplayer;
        _tween.timeScale = endValue;
    }
}
