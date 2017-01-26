using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // Visible in the Inspector
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;   // Local Member Variable to hold the Rigidbody Reference

    public float speed = 1.0f;      // Control the ship's speed
    public float tilt = 1.0f;       // Control the amount of tilting the craft does
    public Boundary boundary;       // Instance of Boundary

    public GameObject shot;         // Container for shot
    public Transform shotSpawn;     // Container for Transform and Rotational information for shotSpawn GameObject
    public float fireRate = 1.0f;   // Control the firerate of the player ship's weapon

    private float nextFire;         // Allows for a non instant fireRate (the delay)

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access the local RigidBody component
    }

    // Update is called once per frame
    void Update()
    {
        // Player Shooting Code
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    // FixedUpdate is called automatically after each fixed physics stepped.
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Store Player Horizontal Movement input in variable
        float moveVertical = Input.GetAxis("Vertical");     // Store Player Verticle Movement input in variable

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);    // Get 

        rb.velocity = movement * speed;
        // Clamp the position of the player so that it can't exit the player's view space
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
