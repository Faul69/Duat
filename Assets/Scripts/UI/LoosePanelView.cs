using System.Collections.Generic;
using UnityEngine;

public class LoosePanelView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enables;
    [SerializeField] private List<GameObject> _disables;

    public void ViewEndPanel()
    {
        ChangeEnable(_enables, true);
        ChangeEnable(_disables, false);
    }

    private void ChangeEnable(List<GameObject> list, bool changeTo)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(changeTo);
        }
    }
}
