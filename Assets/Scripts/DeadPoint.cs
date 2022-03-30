using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * DeadPoint, verifica si el jugador cay� de la plataforma al vac�o.
 * 
 * @author: jreyes
 */
public class DeadPoint : MonoBehaviour
{
    /*
     * @param collision: hace referencia al objeto que choc� con este
     * revisa si hubo una colisi�n entre 2 objetos, en caso de ser con
     * el jugador entonces reinicia el nivel 1
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Scenes.Deads())
        {
            if (collision.gameObject.tag == Constants.PLAYER)
            {
                SceneManager.LoadScene(Constants.LVL1);
            }
        }
    }
}
