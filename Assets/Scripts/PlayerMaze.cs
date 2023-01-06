using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMaze : MonoBehaviour
{
    public float speed = 5.0f;

    public Text youWin;

    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime , 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "exit")
        {
            youWin.text = "YOU WIN!!!";
            Destroy(this);
            
        }
        
    }

    public void die()
    {
        if (alive)
        {
            // audioS.clip = deathSound;
            // audioS.Play();
            alive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      
    }
}