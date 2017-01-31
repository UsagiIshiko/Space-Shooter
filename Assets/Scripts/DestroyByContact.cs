using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue = 1;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        // Find GameObject with GameController tag
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        // If found, add the found GameController Instance reference to the gameController variable
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        // If not found, send error
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);        // Detects what GameObject is hitting the collider
        if (other.tag == "Boundary")    // If other GameObject has the 'Boundary' tag
        {
            return;                     // End function here.
        }
        Instantiate(explosion, transform.position, transform.rotation); // Create an explosion at the Asteroid's location
        // Create Player Explosion if Player hits the Asteroid
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();  // Calls GameOver Function when Game is Over.
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);      // Destroys the GameObject that hits the collider (the Asteroid)
        Destroy(gameObject);            // Destroys the GameObject itself (the Asteroid itself)
    }
}
