using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlatformTestScript
{
    /// <summary>
    /// Test que comprueba si la plataforma se mueve correctamente hacia arriba
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator PlatformMoveUpwards()
    {
        // Creamos el objeto de la plataforma
        GameObject go_platform = new GameObject();
        PlatformController platform = go_platform.AddComponent<PlatformController>();

        // Asignamos los datos iniciales para la plataforma
        go_platform.transform.position = new Vector3(0f, 10f, 0f);

        platform.movementSpeed = 10f;
        platform.maxY = go_platform.transform.position.y + 2f;
        platform.minY = go_platform.transform.position.y;

        // Levantamos la plataforma
        platform.Move();

        // Esperamos cierto tiempo
        yield return new WaitForSeconds(5);

        // Comprobamos que se da la situacion esperada
        Assert.True(go_platform.transform.position.y >= platform.maxY);
    }

    /// <summary>
    /// Test que comprueba si la plataforma se mueve correctamente hacia abajo
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator PlatformMoveDownwards()
    {
        // Creamos el objeto de la plataforma
        GameObject go_platform = new GameObject();
        PlatformController platform = go_platform.AddComponent<PlatformController>();

        // Asignamos los datos iniciales para la plataforma
        go_platform.transform.position = new Vector3(0f, 10f, 0f);

        platform.movementSpeed = 10f;
        platform.maxY = go_platform.transform.position.y + 2f;
        platform.minY = go_platform.transform.position.y;

        // Levantamos la plataforma
        platform.Move();

        // Esperamos cierto tiempo
        yield return new WaitForSeconds(5);

        // Bajamos la plataforma
        platform.Move();

        // Esperamos cierto tiempo
        yield return new WaitForSeconds(5);
        
        // Comprobamos que se da la situacion esperada
        Assert.True(go_platform.transform.position.y <= platform.minY);
    }
}
