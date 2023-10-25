using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameManager _gm;

    [SerializeField] private bool _red;
    [SerializeField] private bool _grey;

    private Collider _collider;
    private void Start()
    {
        _gm = GameManager.Instance;
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_red && collision.gameObject.CompareTag("Ramon"))
        {
            gameObject.SetActive(false);
            _gm.AddCoins(0);
        }
        if (_grey && collision.gameObject.CompareTag("Cajal"))
        {
            gameObject.SetActive(false);
            _gm.AddCoins(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
