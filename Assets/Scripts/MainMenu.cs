using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * MainMenu Script, se encarga de la función de los botones del menu principal
 * 
 * @author: jreyes
 */

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * @param scene: es un string que define a cual escena irá
     * el juego, esto se define a cada boton que mande a llamar
     * este metodo por medio de la interfaz de unity.
     */
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    /*
     * La función ExitGame se encarga de cerrar el juego directamente
     * solo es llamada por el boton de exit.
     */
    public void ExitGame()
    {
        Application.Quit();
    }
}
