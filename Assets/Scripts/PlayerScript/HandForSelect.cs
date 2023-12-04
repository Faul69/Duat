using UnityEngine;

public class HandForSelect : MonoBehaviour
{
    [SerializeField] private GameObject _grapReference;
    [SerializeField] private GameObject _pistolReference;

    private GameObject _currentHand;
    private GameObject _grapHand;
    private GameObject _pistolHand;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        ChangeHand(false);
    }

    public void DirectHand(Vector3 position)
    {
        _currentHand.transform.position = position;
        _currentHand.transform.LookAt(transform.position);
    }

    public void ResetPosition()
    {
        _currentHand.transform.position = Vector3.zero;
    }

    public void ChangeHand(bool isThrow)
    {
        if (_currentHand != null)
            ResetPosition();

        if (isThrow)
            _currentHand = _pistolHand;
        else
            _currentHand = _grapHand;
    }

    private void Init()
    {
        _grapHand = Instantiate(_grapReference);
        _grapHand.transform.position = Vector3.zero;
        _pistolHand = Instantiate(_pistolReference);
        _pistolHand.transform.position = Vector3.zero;
    }
}
