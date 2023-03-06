using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables.
    private Rigidbody2D rb;
    
    [Header("Movement")]
    [SerializeField] private float jumpForce;

    [Header("Game related")]
    [SerializeField] private GameManager manager;
    [SerializeField] private string boundsTag;

    // Start is called before the first frame update.
    private void Start()
    {
        // Returns the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();   

        // Sets Rigidbody to kinematic.
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame.
    private void Update()
    {
        // Calls necessary methods for gameplay.
        Jump();
    }

    // OnTriggerEnter2D is called when the game object has entered a trigger (a collider that does not interact with objects).
    private void OnTriggerEnter2D(Collider2D collider)
    {
        manager.Interaction(collider.gameObject);
    }

    // OnCollisionEnter2D is called when the game object has collided with another game object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.Interaction(collision.gameObject);
    }

    // OnTriggerExit2D is called when the game object has exited a trigger (a collider that does not interact with objects).
    private void OnTriggerExit2D(Collider2D collider)
    {
        // Check if bounds have been exited.
        Bounds(collider.gameObject);
    }

    // Jump handles player jumping.
    private void Jump()
    {
        // Checks if the left mouse button has been pressed.
        if(Input.GetMouseButtonDown(0))
        {
            // Applies an upward force to the player.
            rb.velocity = Vector2.up * jumpForce;

            // Checks if the game has started.
            if(!manager.gameProgressing)
            {
                manager.StartGame(rb);
            }
        }
    }

    // Bounds checks if the player has exited the play area and should initiate game over.
    private void Bounds(GameObject obj)
    {
        // Checks if the trigger exited was the bounds by checking the tag.
        if(obj.CompareTag(boundsTag))
        {
            // If so, initiate game over.
            manager.GameOver();
        }
    }
}
