using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelDeViento : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuerzaViento = 10f;
    public Vector3 dirViento = Vector2.left;
    public float distanciaViento = 5f;
    private bool inTrigger;
    private Collider2D jugador;
     private void Update(){
        if(inTrigger){
            Debug.Log("PA ATRAS");
            float distancia = Vector3.Distance(transform.position , jugador.transform.position);
            float fuerza = Mathf.Clamp01(1 - (distancia / distanciaViento));
            jugador.GetComponent<Rigidbody>().AddForce(dirViento * fuerzaViento * fuerza);
        }
     }
     private void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player")){
            Debug.Log("Colision");
            inTrigger = true;
            jugador = other;
        }
     }
      private void OnTriggerExit2D(Collider2D other)
     {
            inTrigger = false;
     }
}
