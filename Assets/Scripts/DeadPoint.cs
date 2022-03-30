using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPoint : MonoBehaviour
{
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
