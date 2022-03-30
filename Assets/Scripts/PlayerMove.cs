using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * PlayerMove Script, se encarga de los movimientos que tendrá el personaje
 * 
 * @author: jreyes
 */
public class PlayerMove : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    bool grounded;
    public GameObject bulletPreFab;

    private Rigidbody2D rb2D;
    private Animator animator;
    float horizontal;

    // Start is called before the first frame update
    // inicializa el objeto rb2D y aanimator el cual se encarga de 
    // gestionar las animaciones.
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*
     * En este método lo que hacemos es recibir el
     * input de a donde caminará el jugador, luego verifica la direccion
     * para poder hacer un escalado y que el jugador no camine de espaldas
     */
    void Update()
    {
        horizontal = Input.GetAxisRaw(Constants.HORIZONTAL);
        
        if(horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-0.3699744f, 0.3629115f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(0.3699744f, 0.3629115f, 1.0f);   
        }

        /*Activa la animación de correr*/
        animator.SetBool(Constants.RUNNING, horizontal != 0.0f);

        /* Valida que el jugador esté en el suelo para poder brincar
         * y de esta manera evitar los flappy bird.
         */
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
            animator.SetBool(Constants.JUMPING, false);
        }
        else
        {
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            animator.SetBool(Constants.RUNNING, false);
            animator.SetBool(Constants.JUMPING, grounded);
            Jump();
        }

        /*
         * verifica si la tecla Z es pulsada y luego manda a llamar al metodo
         * Shoot
         */
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal, rb2D.velocity.y);
    }

    /*
     * Este metodo ejecuta la accion de brincar
     */
    private void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce);
    }

    /*
     * Este metodo ejecuta la accion de disparar, dando dirección
     * y utilzando el método pre-fabricado de bullet.
     */
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.3699744f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletPreFab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        
    }
}
