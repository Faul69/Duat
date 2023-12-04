using System;
using System.Collections;
using UnityEngine;

public class OldInputSystem : MonoBehaviour
{
    [SerializeField] private float _delayToUse;

    private bool _isDelay;
    private Vector3 _mousePos;
    private Vector3 _lastPos;

    public event Action<Vector3> MousePosChanged;
    public event Action LeftButtonClicked;

    private void Update()
    {
        SendMousePosition();

        if (!_isDelay)
            MouseButtonClick();
    }

    private void SendMousePosition()
    {
        _mousePos = Input.mousePosition;

        if (_lastPos != _mousePos)
        {
            _lastPos = _mousePos;
            MousePosChanged.Invoke(_lastPos);
        }
    }

    private void MouseButtonClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            SendMousePosition();

        if (Input.GetKeyUp(KeyCode.Mouse0) && !CheckUIOnWay())
        {
            LeftButtonClicked.Invoke();
            StartCoroutine(Detain());
        }
    }

    private bool CheckUIOnWay()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(_lastPos.x, _lastPos.y, Camera.main.nearClipPlane));

        if (Physics.Raycast(ray, out RaycastHit cameraHit))
        {
            if (cameraHit.collider.gameObject.TryGetComponent<ButtonTag>(out _))
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator Detain()
    {
        _isDelay = true;
        yield return new WaitForSeconds(_delayToUse);
        _isDelay = false;
    }
}
