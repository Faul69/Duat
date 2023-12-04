using UnityEngine;

[RequireComponent(typeof(SoulMover))]
[RequireComponent(typeof(SoulVisualiser))]
[RequireComponent(typeof(SoulActions))]
[RequireComponent(typeof(ColorSender))]

public class SoulBuilder : MonoBehaviour
{
    private SoulType _soulBase;
    private SoulMover _mover;
    private ColorSender _colorSender;
    private SoulActions _soulActions;
    private CollisionTouch _touch;

    public SoulType Base => _soulBase;
    public bool IsPickeble => _soulBase.IsPickble;

    private void OnEnable()
    {
        _mover = GetComponent<SoulMover>();
        _colorSender = GetComponent<ColorSender>();
        _soulActions = GetComponent<SoulActions>();
        _touch = GetComponentInChildren<CollisionTouch>();
    }

    public void Init(SoulType soul, Bomber bomber, PositionRebuilder rebuilder, Transform path = null)
    {
        _soulBase = soul;
        _mover.Init(path, rebuilder);
        _colorSender.Init(_soulBase.Color, bomber);
        _soulActions.Init();
        _touch.Init(rebuilder);
        UseBase();
    }

    private void UseBase()
    {
        gameObject.name = _soulBase.Label;
        Instantiate(_soulBase.Body, gameObject.transform);
    }
}
