using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mark a ScriptableObject-derived type to be automatically listed in the Assets/Create submenu,
// so that instances of the type can be easily created and stored in the project as ".asset" files.

// menuName, The display name for this type shown in the Assets/Create menu.

/**
 * This class represents each flock's SteeredCohesion behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior : FlockBehavior
{
    // Store the current velocity, this value is modified by the Vector2.SmoothDamp function every time called.
    private Vector2 currVelocity;
    // Set the smooth time.
    public float flockAgentSmoothTime = 0.5f;
    
    // Override CalculateMove method from FlockBehavior class.
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // If no neighbours, Then keep the flock agent's original direction.
        if (neighbourAgentsTransforms.Count == 0)
            return Vector2.zero;
        
        // Get the average value of all neighbour flock agents' positions' sum.
        
        // Initialize the SteeredCohesion move Vector2.
        var SteeredCohesionMove = Vector2.zero;
        
        // Add all neighbour flock agents' positions together.
        foreach (var neighbourTransform in neighbourAgentsTransforms)
        {
            SteeredCohesionMove += (Vector2)neighbourTransform.position;
        }
        
        // Get the average position.
        SteeredCohesionMove /= neighbourAgentsTransforms.Count;
        
        // Create offset from each agent's position.
        SteeredCohesionMove -= (Vector2)currAgent.transform.position;
        
        // Gradually changes a vector2 towards a desired goal over time.
        SteeredCohesionMove = Vector2.SmoothDamp(currAgent.transform.up, SteeredCohesionMove,
            ref currVelocity, flockAgentSmoothTime);

        return SteeredCohesionMove;
    }
}