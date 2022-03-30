using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * CameraScript, se encarga del comportamiento de la camara.
 * 
 * @author: jreyes
 */

public class CameraScirpt : MonoBehaviour
{
    /*
     * referenciamos al jugador
     */
    public GameObject player;
    
    // Update is called once per frame
    /*
     * tomamos la posicion X del jugador e igualamos la posicion de la camara
     * a esa posicion X para que pueda dar un efecto de seguir al jugador.
     */
    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        transform.position = position;
    }
}
