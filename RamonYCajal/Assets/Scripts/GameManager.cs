using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private UIManager _ui;
    [SerializeField] private GameObject _Ramon;
    [SerializeField] private GameObject _Cajal;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] AudioSource _music;
    private int _redCoins= 0;
    private int _greenCoins= 0;
    [SerializeField] private int _redMaxCoins= 0;
    [SerializeField] private int _greyMaxCoins= 0;
    [SerializeField] private int _minHeight;

    [SerializeField] private AudioMixer _vfx;
    [SerializeField] private AudioMixer _uiMixer;

    private Vector2 _spawnCajal;
    private Vector2 _spawnRamon;

    private bool _paused= false;
    public bool hints = false;
    //Singleton
    private static GameManager _instance;
    [SerializeField] private AudioSource _coinSound;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        _ui.UpdateCoins(0, 0, _redMaxCoins, _greyMaxCoins);
        _spawnCajal = _spawnPoint.transform.position;
        _spawnRamon = new Vector2(_spawnPoint.transform.position.x + 3.0f, _spawnPoint.transform.position.y);

        _Cajal.transform.position = _spawnCajal;
        _Ramon.transform.position = _spawnRamon;
    }
    private void Update()
    {
        //Code for oppening the pause menu with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused) Pause();
            else if (_paused) Resume();
        }
    }
    private void FixedUpdate()
    {
        if (_Ramon.transform.position.y<_minHeight)
        {
            _Ramon.transform.position = _spawnRamon;
        }
        if (_Cajal.transform.position.y < _minHeight)
        {
            _Cajal.transform.position = _spawnCajal;
        }
    }
    public GameObject GetCajal()
    {
        return _Cajal;
    }
    public GameObject GetRamon()
    {
        return _Ramon;
    }

    public void AddCoins(int type)
    {
        if (type == 0) _redCoins++;
        if (type == 1) _greenCoins++;

        _ui.UpdateCoins(_redCoins, _greenCoins, _redMaxCoins, _greyMaxCoins);
    }
    public UIManager GetUIManager() 
    {
        return _ui;
    }
    private void Pause()
    {
        _ui.OpenScapeMenu();
        Time.timeScale = 0;
        _paused = true;
    }
    public void Resume()
    {
        _ui.CloseScapeMenu();
        _ui.CloseOptionsMenu();
        Time.timeScale = 1;
        _paused = false;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void CajalDeath()
    {
        _Cajal.transform.position = _spawnCajal;
    }

    public void PlayCoinSound()
    {
        _coinSound.Play();  
    }
    /// <summary>
    /// Changes the global volume 
    /// </summary>
    /// <param name="value"></param> From 0 to 1
    public void ChangeSound(float value, int type)
    {
        switch(type)
        {
            case 0:
                AudioListener.volume = value;
                break;
            case 1:
                _music.volume = value/4;
                break;
            case 2:
                _vfx.SetFloat("Volume", Mathf.Log10(value*100)*20);
                break;
        }    
    }

}
