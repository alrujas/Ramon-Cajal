using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _ui;
    [SerializeField] private GameObject _Ramon;
    [SerializeField] private GameObject _Cajal;

    private int _redCoins= 0;
    private int _greenCoins= 0;
    [SerializeField] private int _redMaxCoins= 0;
    [SerializeField] private int _greyMaxCoins= 0;

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
}
