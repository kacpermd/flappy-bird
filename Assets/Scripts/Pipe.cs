using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Variables.
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private string boundsTag;

    // Start is called before the first frame update.
    private void Start()
    {
        // Returns the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame.
    private void Update()
    {
        // Calls necessary methods.
        Move();
    }

    // OnTriggerExit2D is called when the game object has exited a trigger (a collider that does not interact with objects).
    private void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the trigger exited was the bounds trigger.
        Bounds(collider.gameObject);
    }

    // Moves handles pipe movement.
    private void Move()
    {
        // Moves the pipe.
        rb.velocity = Vector2.left * speed;
    }

    // Bounds checks if the pipe has exited the play area and should be destroyed.
    private void Bounds(GameObject obj)
    {
        // Checks if the pipe has exited the bounds trigger, if so...
        if(obj.CompareTag(boundsTag))
        {
            // Destroy the pipe.
            Destroy(gameObject);
        }
    }
}
