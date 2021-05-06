using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the FlockBehavior class and represents each flock's alignment behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/FilteredAlignment")]
public class FilteredAlignmentBehavior : FilteredFlockBehavior
{
    // Override CalculateMove method from FlockBehavior class.
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // If no current flock's neighbours, Then keep the flock agent's original direction.
        if (contextFilter.FilterFlockAgent(currAgent, neighbourAgentsTransforms).Count == 0)
            return Vector2.up;
        
        // Get the average value of all neighbour flock agents' directions' sum.
        
        // Initialize the alignment move Vector2.
        var alignmentMove = Vector2.zero;
        
        // First check if context filter exists.
        // If not, then just use original NeighbourAgentsTransforms.
        // If so, then use filtered original NeighbourAgentsTransforms as new NeighbourAgentsTransforms.
        var filteredNeighbourAgentsTransforms = (contextFilter == null) ? neighbourAgentsTransforms 
            : contextFilter.FilterFlockAgent(currAgent, neighbourAgentsTransforms);
        
        // Add all neighbour flock agents' directions together.
        foreach (var neighbourTransform in filteredNeighbourAgentsTransforms)
        {
            alignmentMove += (Vector2)neighbourTransform.up;
        }
        
        // Get the average direction.
        alignmentMove /= filteredNeighbourAgentsTransforms.Count;

        return alignmentMove;
    }
}
