using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gm;

    [SerializeField] private TMPro.TMP_Text _redCoins;
    [SerializeField] private TMPro.TMP_Text _greyCoins;

    [SerializeField] private GameObject _endLevel;

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
}
