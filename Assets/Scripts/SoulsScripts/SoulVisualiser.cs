using DG.Tweening;
using UnityEngine;

public class SoulVisualiser : MonoBehaviour
{
    private const float LowScale = 0.1f;

    [SerializeField] private float _normalScale;

    private GameObject _visualBody;
    private bool _isVisible;

    private void Start()
    {
        _visualBody = GetComponentInChildren<VisualBody>().gameObject;
        TurnChildsIntractble(false);
    }

    public void Disappear(float speed)
    {
        GetComponent<SphereCollider>().enabled = false;
        _visualBody.transform.DOScale(LowScale, speed);

    }

    public void Appear(float speed)
    {
        if (!_isVisible)
            TurnChildsIntractble(true);

        _visualBody.transform.DOScale(_normalScale, speed);
        GetComponent<SphereCollider>().enabled = true;
    }

    public void TurnChildsIntractble(bool isActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(isActive);
        }

        _isVisible = isActive;
    }

}