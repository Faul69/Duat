using Plugins.Audio.Core;
using UnityEngine;

public class AudioLiblary : MonoBehaviour
{
    [SerializeField] private SourceAudio _source;

    public void PlayButtonClick()
    {
        _source.Play("ButtonClick");
    }

    public void PlayLowCombo()
    {
        _source.Play("ComboLow");
    }

    public void PlayComboMid()
    {
        _source.Play("ComboMid");
    }

    public void PlayComboStrong()
    {
        _source.Play("ComboStrong");
    }

    public void PlayLooseSound()
    {
        _source.Play("LooseSound");
    }
    
    public void PlayThrowSoul()
    {
        _source.Play("ThrowSoul");
    }
    
    public void PlayWinSound()
    {
        _source.Play("WinSound");
    }

    public void PlayPickSound()
    {
        _source.Play("PickSoul");
    }
}
