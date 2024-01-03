using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    /// <summary>
    /// Type of the sound, 0 is global, 1 is music, 2 is sound effects
    /// </summary>
    [SerializeField] private int _type = 0;
    private GameManager _gm;
    private UIManager _ui;

    [SerializeField] private Slider _slider;
    private Image _image;
    [SerializeField] private Sprite _noMuted;
    [SerializeField] private Sprite _muted;
    private bool _mutedBool = false;
    private float _volume = 0;

    private void Start()
    {
        _gm = GameManager.Instance;
        _ui = _gm.GetUIManager();
        _image = GetComponent<Image>();
    }
    /// <summary>
    /// On button Click. Mutes the audio or unmutes it
    /// </summary>
    public void Mute()
    {
        if (_mutedBool)
        {
            _slider.value = _volume;
            _mutedBool = false;
            _image.sprite = _noMuted;
            _gm.ChangeSound(_volume/100, _type);
        }
        else
        {
            _volume = _slider.value;  
            _slider.value = 0;
            _mutedBool = true;
            _image.sprite = _muted;
            _gm.ChangeSound(0, _type);
        }
    }
    /// <summary>
    /// On Value Change slider. Changes the volume depending of the slider value.
    /// </summary>
    public void ChangeVolume()
    {
        _mutedBool = false;
        _image.sprite = _noMuted;
        _gm.ChangeSound(_slider.value / 100, _type);
    }
    
}
