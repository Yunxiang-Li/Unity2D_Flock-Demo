using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mark a ScriptableObject-derived type to be automatically listed in the Assets/Create submenu,
// so that instances of the type can be easily created and stored in the project as ".asset" files.

// menuName, The display name for this type shown in the Assets/Create menu.

/**
 * This class inherits from the FlockBehavior class and represents each flock's cohesion behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior
{
    // Override CalculateMove method from FlockBehavior class.
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // If no neighbours, Then keep the flock agent's original direction.
        if (neighbourAgentsTransforms.Count == 0)
            return Vector2.zero;
        
        // Get the average value of all neighbour flock agents' positions' sum.
        
        // Initialize the cohesion move Vector2.
        var cohesionMove = Vector2.zero;
        
        // Add all neighbour flock agents' positions together.
        foreach (var neighbourTransform in neighbourAgentsTransforms)
        {
            cohesionMove += (Vector2)neighbourTransform.position;
        }
        
        // Get the average position.
        cohesionMove /= neighbourAgentsTransforms.Count;
        
        // Create offset from each agent's position.
        cohesionMove -= (Vector2)currAgent.transform.position;

        return cohesionMove;
    }
}
