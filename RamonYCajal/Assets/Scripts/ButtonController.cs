using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    private SpriteRenderer buttonRenderer;

    /// <summary>
    /// Objeto de la puerta
    /// </summary>
    public GameObject door;
    
    private void Start(){
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonRenderer.sprite = normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorController doorController = door.GetComponent<DoorController>();
            // Comprobamos que la puerta no esta en movimiento y que este cerrada
            if (!doorController.isMoving && !doorController.doorState)
            {
                doorController.Open();
                buttonRenderer.sprite = pressedSprite;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonRenderer.sprite = normalSprite;
        }
    }
}
