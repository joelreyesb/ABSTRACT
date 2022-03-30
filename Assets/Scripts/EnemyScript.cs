using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPreFab;

    public float lastShoot;

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.493193f, 1.615587f, 1.0f);
        else transform.localScale = new Vector3 (-1.493193f, 1.615587f, 1.0f);

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distance < 1.0f)
        {
            Shot();
        }
    }

    private void Shot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.3699744f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletPreFab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
}
