using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Animator anim;
    bool playerInExplosionArea = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerMaze"))
        {
            anim.SetTrigger("Explode");
        }

        playerInExplosionArea = true;

        player = other.gameObject;
    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerInExplosionArea = false;
    }

    void DestroyBomb()
    {   
        if (playerInExplosionArea)
        {            
            player.GetComponent<PlayerMaze>().die();
        }
        Destroy(gameObject);
    }
}
