using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    public enum SoundState
    {
        On,
        Off
    }
    
    [SerializeField] private SoundState _onOff = SoundState.On;
    private Image _imageComponent;
    private Sprite _onImage;
    private Sprite _offImage;

    public void SoundOnOff()
    {
        if (_onOff == SoundState.On)
        {
            _onOff = SoundState.Off;
            _imageComponent.sprite = _offImage;
            Managers.Sound.Mute();
            
        }
        else
        {
            _onOff = SoundState.On;
            _imageComponent.sprite = _onImage;
            Managers.Sound.UnMute();
            
        }
    }

    private void Start()
    {
        _imageComponent = gameObject.GetComponent<Image>();
        _onImage = Managers.Resource.Load<Sprite>("Art/Icons/Sound On");
        _offImage = Managers.Resource.Load<Sprite>("Art/Icons/Sound Off");
        
        Managers.Sound.Play("Bgm/Birds", Define.Sound.Bgm);
    }
}
