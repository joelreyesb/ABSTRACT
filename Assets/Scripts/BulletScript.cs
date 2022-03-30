using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BulletScript, se encarga del movimiento de las balas.
 * 
 * @author: jreyes
 */

public class BulletScript : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    // instancia el rb2D
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // le da un movimiento a la bala
    void FixedUpdate()
    {
        rb2D.velocity = direction * speed;   
    }

    /*
     * @param direction: recibe la direccion a la que esta
     * volteando el personaje en ese momento.
     */
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
