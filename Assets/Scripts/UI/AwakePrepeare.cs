using System.Collections.Generic;
using UnityEngine;

public class AwakePrepeare : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsEnable;
    [SerializeField] private List<GameObject> _objectsDisable;

    private void Awake()
    {
        ChangeEnable(_objectsEnable, true);
        ChangeEnable(_objectsDisable, false);
    }

    private void ChangeEnable(List<GameObject> list, bool changeTo)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(changeTo);
        }
    }
}

