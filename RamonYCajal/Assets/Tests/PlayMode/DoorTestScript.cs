using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorTestScript
{
    /// <summary>
    /// Test que comprueba si la puerta se mueve correctamente hacia arriba
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator DoorMoveUpwards()
    {
        // Creamos el objeto de la puerta
        GameObject go_door = new GameObject();
        DoorController door = go_door.AddComponent<DoorController>();

        // Asignamos los datos iniciales para la puerta
        go_door.transform.position = new Vector3(0f, 0f, 0f);

        door.movementSpeed = 10f;
        door.maxY = go_door.transform.position.y + 4f;
        door.minY = go_door.transform.position.y;
        door.timeToClose = 10;

        // Abrimos la puerta
        door.Open();

        // Esperamos cierto tiempo
        yield return new WaitForSeconds(1);

        // Comprobamos que se da la situacion esperada
        Assert.True(go_door.transform.position.y > door.minY);
    }

    /// <summary>
    /// Test que comprueba si la puerta se mueve correctamente hacia abajo
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator DoorMoveDownwars()
    {
        // Creamos el objeto de la puerta
        GameObject go_door = new GameObject();
        DoorController door = go_door.AddComponent<DoorController>();

        // Asignamos los datos iniciales para la puerta
        go_door.transform.position = new Vector3(0f, 10f, 0f);

        door.movementSpeed = 10f;
        door.maxY = go_door.transform.position.y + 1f;
        door.minY = go_door.transform.position.y;
        door.timeToClose = 3;

        // Abrimos la puerta
        door.Open();

        // Esperamos a que la puerta acabe de cerrarse por si sola
        yield return new WaitForSeconds(10);

        // Comprobamos que se da la situacion esperada
        Assert.True(go_door.transform.position.y <= door.minY);
    }
}
