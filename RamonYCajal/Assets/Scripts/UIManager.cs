using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gm;

    [SerializeField] private TMPro.TMP_Text _redCoins;
    [SerializeField] private TMPro.TMP_Text _greyCoins;

    [SerializeField] private GameObject _endLevel;

    [SerializeField] private GameObject _scapeMenu;
    [SerializeField] private GameObject _optionsMenu;


    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoins(int red, int grey, int redMax, int greyMax)
    {
        _redCoins.text = red + "/" + redMax;
        _greyCoins.text = grey + "/" + greyMax;
    }

    public void EndLevel()
    {
        _endLevel.SetActive(true);
    }
    public void OpenScapeMenu()
    {
        _scapeMenu.SetActive(true);
    }
    public void CloseScapeMenu()
    {
        _scapeMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        _optionsMenu.SetActive(true);
        _scapeMenu.SetActive(false);
    }
    public void CloseOptionsMenu()
    {
        _optionsMenu.SetActive(false);
    }

    public void ChangeHintsBool()
    {
        _gm.hints = !_gm.hints;
    }

}
