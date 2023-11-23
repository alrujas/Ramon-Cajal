using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonDetenerViento : MonoBehaviour
{
   // Referencia al objeto del túnel de viento
    public GameObject _tunelDeViento;
    public GameObject _viento2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ramon"))
        {
            // Desactivar el componente TunelDeViento (o puedes desactivar el objeto completo)
            _tunelDeViento.GetComponent<Viento>().enabled = false;
            _tunelDeViento.GetComponent<Animator>().enabled = false;
            _tunelDeViento.GetComponent<SpriteRenderer>().enabled = false;
            _viento2.GetComponent<Animator>().enabled = false;
            _viento2.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ramon"))
        {
            // Desactivar el componente TunelDeViento (o puedes desactivar el objeto completo)
            _tunelDeViento.GetComponent<Viento>().enabled = true;
            _tunelDeViento.GetComponent<Animator>().enabled = true;
            _tunelDeViento.GetComponent<SpriteRenderer>().enabled = true;
            _viento2.GetComponent<Animator>().enabled = true;
            _viento2.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
