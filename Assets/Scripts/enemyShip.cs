using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    public GameObject bullet;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0f;
        }            
        transform.Translate(new Vector3(0, -0.05f, 0));
        if (transform.position.y <= -10f)
            Destroy(gameObject);
    }
}
