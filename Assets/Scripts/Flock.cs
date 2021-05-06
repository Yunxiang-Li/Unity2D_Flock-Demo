using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class represents all Flock objects' behaviors.
 */
public class Flock : MonoBehaviour
{
	// Store the FlockAgent prefab.
	public FlockAgent agentPrefab;
	
	// Create a List to store all FLockAgent objects.
	private readonly List<FlockAgent> flockAgents = new List<FlockAgent>();
	
	// Store the FlockBehavior.
	public FlockBehavior behavior;
	
	// Set each flock's agent numbers.(250 as default)
	[Range(10, 500)] public int startingCount = 250;
	
	// Set each flock's agent density to be 0.08.
	private const float AgentDensity = 0.08f;
	
	// Set each flock agent's drive factor.(10 as default)
	[Range(1f, 100f)] public float driveFactor = 10f;
	
	// Set each flock agent's max speed.(5 as default)
	[Range(1f, 100f)] public float maxSpeed = 5f;
	
	// Set each flock 's neighbour radius.(1.5 as default)
	[Range(1f, 10f)] public float neighbourRadius = 1.5f;
	
	// Set each flock 's avoidance radius multiplier.(0.5 as default)
	[Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

	// Store squares to calculate easier later.
	private float squareMaxSpeed;
	private float squareNeighbourRadius;

	public float getSquareAvoidanceRadius { get; private set; }

	// Use this for initialization
	private void Start ()
	{	
		// Get 3 square values.
		squareMaxSpeed = maxSpeed * maxSpeed;
		squareNeighbourRadius = neighbourRadius * neighbourRadius;
		getSquareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

		// Spawn 250(startingCount) FlockAgent objects.
		for (var i = 0; i < startingCount; i++)
		{
			// Instantiate each FlockAgent object randomly.
			var newAgent = Instantiate(agentPrefab,
				Random.insideUnitCircle * startingCount * AgentDensity,
				Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
				transform);
			// Set each FlockAgent object's name.
			newAgent.name = "Agent " + i;
			// Set each FLockAgent object's Flock.
			newAgent.Initialize(this);
			// Add each FlockAgent object to the Flock's FlockAgent List.
			flockAgents.Add(newAgent);
		}
	}
	
	// Update is called once per frame
	private void Update () {
		
		// Get each flock agent object's neighbour flock agents' transform and apply behaviors.
		foreach (var flockAgent in flockAgents)
		{
			// Get each flockAgent object's neighbour flockAgents' Transform.
			var neighbourFlockAgents = GetNearbyObjects(flockAgent);

			// Get each flockAgent's move Vector2.
			var moveVec = behavior.CalculateMove(flockAgent, neighbourFlockAgents, this);
			moveVec *= driveFactor;
			
			// Check if moveVec 's magnitude square is greater than max speed's square.
			if (moveVec.sqrMagnitude > squareMaxSpeed)
				// Reset moveVec 's magnitude square to max speed's square.
				moveVec = moveVec.normalized * maxSpeed;
			
			// Let each flockAgent object actually move.
			flockAgent.Move(moveVec);
		}
	}

	/**
	 * Get and return a List of Transform of one flockAgent object's nearby flocks(within the neighbour circle).
	 */
	private List<Transform> GetNearbyObjects(FlockAgent flockAgent)
	{
		// Store the result.
		var context = new List<Transform>();
		
		// Get a list of all Colliders2Ds that fall within a circular area
		// (flock agent's position as circle center and neighbour radius as circle radius).
		var contextColliders = Physics2D.OverlapCircleAll(flockAgent.transform.position, neighbourRadius);
		
		// Add each neighbour flock agent's transform to the List.
		foreach (var c in contextColliders)
		{	
			// Check to avoid adding current flock agent's transform.
			if (c != flockAgent.Collider)
				context.Add(c.transform);
		}

		return context;
	}
}
