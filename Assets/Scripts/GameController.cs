using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;

	// Use this for initialization
	void Start () {
        SpawnWaves();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void SpawnWaves ()
    {
        // Spawns the Asteroid within a random range between x and -x, y, and z as specified by the inspector
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity; // Set Rotation to zero
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}
