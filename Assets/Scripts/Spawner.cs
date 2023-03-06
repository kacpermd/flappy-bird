using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Variables.
    [Header("Game Objects")]
    [SerializeField] private GameObject pipe;

    [Header("Spawn Timer")]
    [SerializeField] private float timeBetweenSpawn;
    private float spawnTimer;

    [Header("Randomisation")]
    [SerializeField] private float yRange;

    // Start is called before the first frame update.
    private void Start()
    {
        // Initialises the spawn time.
        spawnTimer = timeBetweenSpawn;
    }

    // Update is called once per frame.
    private void Update()
    {
        // Calls necessary methods.
        Spawn();
    }

    // Spawn handles pipe spawning.
    private void Spawn()
    {
        // Checks if time hasn't ran out.
        if(spawnTimer > 0f)
        {
            // If time hasn't ran out, decrease the timer.
            spawnTimer -= Time.deltaTime;
        }
        else if(spawnTimer <= 0f)
        {
            // If the timer has ran out, spawn a pipe at a random Y position and reset the timer.
            Instantiate(pipe, new Vector2(pipe.transform.position.x, Random.Range(-yRange, yRange)), Quaternion.identity);
            spawnTimer = timeBetweenSpawn;
        }
    }
}
