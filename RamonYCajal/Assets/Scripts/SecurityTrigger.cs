using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _dialog1;
    [SerializeField] private GameObject _dialog2;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ramon") || collision.CompareTag("Cajal"))
        {
         
                _dialog1.SetActive(false);
                _dialog2.SetActive(false);
        }
    }
}
