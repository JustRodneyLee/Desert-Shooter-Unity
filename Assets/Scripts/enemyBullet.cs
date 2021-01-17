using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tag = "enemy";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.SendMessage("TakeDamage");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -0.06f, 0));
        if (transform.position.y <= -10f)
            Destroy(gameObject);
    }
}
