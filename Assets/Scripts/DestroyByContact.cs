using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    // Use this for initialization
    void Start()
    {

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
        }
        Destroy(other.gameObject);      // Destroys the GameObject that hits the collider (the Asteroid)
        Destroy(gameObject);            // Destroys the GameObject itself (the Asteroid itself)
    }
}
