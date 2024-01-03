using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextHint : MonoBehaviour
{ 
     /// <summary>
    /// Gamemanager Object
    /// </summary>
    private GameManager _gm;

    [SerializeField] private GameObject _hint;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cajal") && _gm.hints)
        {
            _hint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _hint.SetActive(false);
    }

}
