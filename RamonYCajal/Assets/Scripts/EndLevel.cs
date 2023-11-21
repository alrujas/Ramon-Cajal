using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private GameManager _gm;
    private UIManager _ui;
    [SerializeField] private ParticleSystem _partSis1;
    [SerializeField] private ParticleSystem _partSis2;
    [SerializeField] private ParticleSystem _partSis3;
    private bool _cajal = false;
    private bool _ramon= false;
    private bool _end= false;
    private AudioSource _endLevelSound;

    private void Start()
    {
        _gm = GameManager.Instance;
        _ui = _gm.GetUIManager();
        _endLevelSound =  GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(_ramon && _cajal)
        {
            _ui.EndLevel();
            End();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ramon")) _ramon = true;
        if (other.CompareTag("Cajal")) _cajal=true;
   }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ramon")) _ramon = false;
        if (other.CompareTag("Cajal")) _cajal = false;
    }

    private void End()
    {
        if (!_end)
        {
            _partSis1.Play();
            _partSis2.Play();
            _partSis3.Play();
            _endLevelSound.Play();
            _end = true;
        }
    }
}
