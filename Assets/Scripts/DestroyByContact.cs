using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

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
        Destroy(other.gameObject);      // Destroys the GameObject that hits the collider (the Asteroid)
        Destroy(gameObject);            // Destroys the GameObject itself (the Asteroid itself)
    }
}
