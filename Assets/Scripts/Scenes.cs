 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    static int dead = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYER)
        {
            SceneManager.LoadScene(Constants.FINAL_SCENE);
        }
    }

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

    public void BackToMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
