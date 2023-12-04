using System.Collections;
using UnityEngine;

public class RotateClouds : MonoBehaviour
{
    private const float CircleDegrees = 360f;

    [SerializeField] private float _speed;

    private float _yRotate = 0;

    private void OnEnable()
    {

    }

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    private void OnDisable()
    {
        StopCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            yield return null;
            _yRotate = Mathf.MoveTowards(_yRotate, CircleDegrees, Time.deltaTime * _speed);
            transform.rotation = new Quaternion(0, _yRotate * Mathf.Deg2Rad, 0, 1);
        }
    }
}
