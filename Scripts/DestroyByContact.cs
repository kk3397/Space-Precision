using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int playerValue;
    private GameController gameController;

     void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject!= null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "boundary")
        {
            return; //ends the execution of if-statement, therefore never reaches the
            //destroy method for boundary
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            gameController.LiveCount();
            if (gameController.isDead)
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Destroy(other.gameObject);


            }

        }
        
        gameController.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
