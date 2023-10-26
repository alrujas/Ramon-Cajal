using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _ui;
    [SerializeField] private GameObject _Ramon;
    [SerializeField] private GameObject _Cajal;

    private int _redCoins= 0;
    private int _greenCoins= 0;
    [SerializeField] private int _redMaxCoins= 0;
    [SerializeField] private int _greyMaxCoins= 0;
    [SerializeField] private int _minHeight;
    private Vector2 _spawnCajal;
    private Vector2 _spawnRamon;

    private bool _paused= false;
    //Singleton
    private static GameManager _instance;
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
        _spawnCajal = _Cajal.transform.position;
        _spawnRamon = _Ramon.transform.position;
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
        Time.timeScale = 1;
        _paused = false;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}