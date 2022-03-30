 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Scenes, Se encarga de cargar algunas escenas.
 * 
 * @author: jreyes
 */
public class Scenes : MonoBehaviour
{
    static int dead = 0;

    /*
     * @param collision: hace referencia al objeto que chocó con este
     * al momento de que el jugador llegue a interactuar con este objeto
     * el juego se va a la escena final.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYER)
        {
            SceneManager.LoadScene(Constants.FINAL_SCENE);
        }
    }

    /*
     * @returns true or false
     * revisa la cantidad de veces que se ha muerto el pesonaje
     * en caso de ser 3 se va a la escena final.
     */
    public static bool Deads()
    {
        dead = dead + 1;
        if (dead == 3)
        {
            SceneManager.LoadScene(Constants.FINAL_SCENE);
            dead = 0;
            return false;
        }
        return true;
    }


    /*
     * @param scene: la escena a la que irá al invocarse este metodo.
     */
    public void BackToMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
