using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the FlockBehavior class and represents each flock's composite behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    // Store all FlockBehavior objects.
    public FlockBehavior[] behaviors;
    // Store all FlockBehavior objects' weight.
    public float[] behaviorsWeights;
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // Handle behavior-weight dis match issue.
        if (behaviors.Length != behaviorsWeights.Length)
        {
            //Debug.LogError("behavior number does not much weight number in " + name, this);
            return Vector2.zero;
        }
         
        // Initialize the total move.
        var totalMove = Vector2.zero;
        
        // Iterate through all behaviors.
        for (var i = 0; i < behaviors.Length; ++i)
        {
            // Get each behavior's move.
            var eachBehaviorMove = behaviors[i].CalculateMove(currAgent,
                neighbourAgentsTransforms, flock) * behaviorsWeights[i];
            // Check if there is a valid move
            if (eachBehaviorMove == Vector2.zero) continue;
            // Check if this behavior's move 's magnitude square exceeds its weights' square.
            if (eachBehaviorMove.sqrMagnitude > behaviorsWeights[i] * behaviorsWeights[i])
            {
                // Then reset this behavior's move 's magnitude square to its weights' square.
                eachBehaviorMove.Normalize();
                eachBehaviorMove *= behaviorsWeights[i];
            }
            // Add this valid behavior's move to the total move.
            totalMove += eachBehaviorMove;
        }
    
        return totalMove;
    }
}
