using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour
{
    public float fuerzaViento = 10f;
    public Vector2 dirViento = Vector2.left;
    public float distanciaViento = 5f;
    private bool inTrigger;
    private Collider2D jugador;
    void Start()
    {

    }
    void Update()
    {
        if(inTrigger){
            float distancia = Vector2.Distance(transform.position, jugador.transform.position);
            float fuerza = Mathf.Clamp01(1 - (distancia / distanciaViento));
            //Vector2 nuevaPosicion = (Vector2)jugador.transform.position + dirViento * fuerzaViento * fuerza * Time.fixedDeltaTime;
            // jugador.GetComponent<Rigidbody2D>().MovePosition(nuevaPosicion);

            // Vector2 fuerzaAplicada = dirViento.normalized * fuerzaViento * fuerza;
            // Debug.Log("Fuerza Aplicada : " + fuerzaAplicada);
            // jugador.GetComponent<Rigidbody2D>().AddForce(fuerzaAplicada);

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
