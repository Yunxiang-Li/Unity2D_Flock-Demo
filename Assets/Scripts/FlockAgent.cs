using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class represents all FlockAgent objects' behaviors.
 */
// Automatically add CircleCollider2D component to each FlockAgent object.
[RequireComponent(typeof(CircleCollider2D))]
public class FlockAgent : MonoBehaviour
{
	// Get and Set function of each FlockAgent object's Flock.
	public Flock Flock { get; private set; }
	
	// Get and Set function of each FlockAgent object's Collider2D component.
	// No need to call GetComponent in each update.
	public Collider2D Collider { get; private set; }

	// Use this for initialization
	private void Start ()
	{	
		// Get Collider2D component.
		Collider = GetComponent<Collider2D>();
	}

	/**
	 * Get and store the current FlockAgent object's Flock.
	 */
	public void Initialize(Flock flock)
	{
		Flock = flock;
	}
	
	/**
	 * Move the current FlockAgent object according to the velocity and deltatime.
	 */
	public void Move(Vector2 velocity)
	{	
		// Set the Y axis (green axis) direction of FlockAgent object.
		transform.up = velocity;
		// Update the new position of FlockAgent object.
		transform.position += (Vector3)(velocity * Time.deltaTime);
	}
}
