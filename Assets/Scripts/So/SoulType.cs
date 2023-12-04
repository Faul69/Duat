using UnityEngine;

[CreateAssetMenu(fileName ="NewSoul", menuName ="Soul", order = 51) ]
public class SoulType : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private string _color;
    [SerializeField] private GameObject _body;
    [SerializeField] private bool _isPickeble;
    [SerializeField] private Sprite _icon;

    public GameObject Body => _body;
    public string Label => _label;
    public string Color => _color;
    public bool IsPickble => _isPickeble;
    public Sprite Icon => _icon;
}
