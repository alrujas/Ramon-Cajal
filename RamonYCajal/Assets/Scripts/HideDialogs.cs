using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDialogs : MonoBehaviour
{
    private GameManager _gm;
    [SerializeField] private GameObject _dialog1;
    [SerializeField] private GameObject _dialog2;
    // Start is called before the first frame update
    void Start()
    {
        _gm= GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ramon"))
        {
            if (_gm.GetCajal().transform.position.x>transform.position.x)
            {
                _dialog1.SetActive(false);
                _dialog2.SetActive(false);
            }
        }
        else
        {
            if(_gm.GetRamon().transform.position.x > transform.position.x)
            {
                _dialog1.SetActive(false);
                _dialog2.SetActive(false);
            }       
        }
    }
}
