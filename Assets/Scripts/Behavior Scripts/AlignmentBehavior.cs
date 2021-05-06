using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the FlockBehavior class and represents each flock's alignment behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    // Override CalculateMove method from FlockBehavior class.
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // If no neighbours, Then keep the flock agent's original direction.
        if (neighbourAgentsTransforms.Count == 0)
            return Vector2.up;
        
        // Get the average value of all neighbour flock agents' directions' sum.
        
        // Initialize the alignment move Vector2.
        var alignmentMove = Vector2.zero;
        
        // Add all neighbour flock agents' directions together.
        foreach (var neighbourTransform in neighbourAgentsTransforms)
        {
            alignmentMove += (Vector2)neighbourTransform.up;
        }
        
        // Get the average direction.
        alignmentMove /= neighbourAgentsTransforms.Count;

        return alignmentMove;
    }
}
