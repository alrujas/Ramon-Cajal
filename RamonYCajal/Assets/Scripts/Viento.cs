using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour
{
    private GameManager gameManager;
    public float fuerzaViento = 10f;
    public Vector2 dirViento = Vector2.left;
    public float distanciaViento = 5f;
    private bool inTrigger;
    private Collider2D jugador;

    private GameObject _cajal;
    private GameObject _ramon;

    [SerializeField] private int _audioDist;
    private AudioSource _audioSource;
    private bool _playingSound= false;
    void Start()
    {
        gameManager = GameManager.Instance;
        _ramon= gameManager.GetRamon();
        _cajal= gameManager.GetCajal();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Vector2.Distance(_cajal.transform.position, transform.position) < _audioDist || Vector2.Distance(_ramon.transform.position, transform.position) < _audioDist)
        {
            
            _audioSource.enabled = true;

            if (!_playingSound) _audioSource.Play();
            _playingSound = true;
        }
        else
        {
           _playingSound= false;
            _audioSource.enabled = false;
        }
        if(inTrigger){
            float distancia = Vector2.Distance(transform.position, jugador.transform.position);
            float fuerza = Mathf.Clamp01(1 - (distancia / distanciaViento));


            jugador.GetComponent<Rigidbody2D>().AddForce(dirViento*fuerza*fuerzaViento, ForceMode2D.Force);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Cajal")) 
        {
         inTrigger = true;
         jugador = other;
        }
   }
    void OnTriggerExit2D(Collider2D other){
            inTrigger = false;
   }
}
