using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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

        animator.SetBool(Constants.RUNNING, horizontal != 0.0f);

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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal, rb2D.velocity.y);
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.3699744f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletPreFab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        
    }
}
