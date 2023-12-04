using System;
using UnityEngine;

public class ColorSender : MonoBehaviour
{
    private const string HappyColor = "Happy";
    public string Color { get; private set; }
    private Bomber _bomber;

    public event Action<string> BackColorSender;
    public event Action<string> FrontColorSender;

    public void StartSendColor()
    {
        _bomber.AddNew(this);
        BackColorSender.Invoke(Color);
        FrontColorSender.Invoke(Color);
    }

    public void FrontSendColor(string color)
    {
        if (color == Color || color == HappyColor)
        {
            _bomber.AddNew(this);
            FrontColorSender.Invoke(Color);
        }
        else if (Color == HappyColor)
        {
            _bomber.AddNew(this);
            FrontColorSender.Invoke(color);
        }
        else
        {
            _bomber.SetFrontEdge(this);
            _bomber.CountEdge();
        }
    }

    public void BackSendColor(string color)
    {
        if (color == Color || color == HappyColor)
        {
            _bomber.AddNew(this);
            BackColorSender.Invoke(Color);
        }
        else if (Color == HappyColor)
        {
            _bomber.AddNew(this);
            BackColorSender.Invoke(color);
        }
        else
        {
            _bomber.SetBackEdge(this);
            _bomber.CountEdge();
        }
    }

    public void SendEdge()
    {
        _bomber.CountEdge();
    }

    public void Init(string color, Bomber counter)
    {
        Color = color;
        _bomber = counter;
    }
}
