using System.Collections.Generic;
using UnityEngine;

public class BagViewer : MonoBehaviour
{
    [SerializeField] private List<SoulType> _soulsReference;

    private List<GameObject> _bodys;
    private SoulBuilder _soulInBag;
    private GameObject _bodyToShow;
    private Vector3 _positionToHide = new(0, -30, 0);

    private void OnEnable()
    {
        _bodys = new List<GameObject>();
        Init();
    }

    public void TakeNewSoul(SoulActions soul)
    {
        if (soul == null)
            return;

        _soulInBag = soul.GetComponent<SoulBuilder>();
        ShowSoul();
    }

    public void Clean()
    {
        _soulInBag = null;
        _bodyToShow.transform.position = _positionToHide;
    }

    private void ShowSoul()
    {
        var soulNumber = _soulsReference.IndexOf(_soulInBag.Base);
        _bodyToShow = _bodys[soulNumber];
        _bodyToShow.transform.position = transform.position;
    }

    private void Init()
    {
        foreach (SoulType reference in _soulsReference)
        {
            var visual = Instantiate(reference.Body, transform);
            visual.transform.position = _positionToHide;
            _bodys.Add(visual);
        }
    }
}
