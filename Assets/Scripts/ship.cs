using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ship : MonoBehaviour
{
    public int health = 3;
    public float score = 0;
    public GameObject bullet;
    public float speed = 0.06f;
    AudioSource shootSound;
    public GameObject explosion;
    public Text hpText;
    public Text scoreText;
    public Text hiscoreText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("hiscore", (int)score);
        health = 3;
        shootSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    public void TakeDamage()
    {
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        score += 0.05f;
        if (health == 0)
        {
            if (PlayerPrefs.GetInt("hiscore") < score)
                PlayerPrefs.SetInt("hiscore", (int)score);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }            

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0));
            //GetComponent<Rigidbody2D>().MovePosition(new Vector2(-speed, 0));
            //transform.position += ;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed, 0));
            //GetComponent<Rigidbody2D>().MovePosition(new Vector2(speed, 0));
            //transform.position += new Vector3(speed, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(new Vector3(0, speed));
            //GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, speed));
            //transform.position += new Vector3(0, speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed));
            //GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, -speed));
            //transform.position += new Vector3(0, -speed);
        }
        hpText.text = "HP " + health.ToString();
        scoreText.text = "SCORE " + ((int)score).ToString().PadLeft(5,'0');
        hiscoreText.text = "HISCORE " + PlayerPrefs.GetInt("hiscore");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootSound.Play();
        }
    }
}
