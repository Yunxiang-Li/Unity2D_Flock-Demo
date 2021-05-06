using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the FlockBehavior class and represents each flock's stay in a certain circle area behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/StayInRadius")]
public class StayInRadiusBehavior : FlockBehavior
{
    // Initialize the circle area's center position.
    public Vector2 centerPos;
    // Initialize the circle area's radius.
    public float radius = 15f;
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // Get the offset Vector2 from current agent's position to center position.
        var centerOffset = centerPos - (Vector2) currAgent.transform.position;
        // Get the ratio of offset Vector2's length divides by the circle area's radius.
        // 0 means offset Vector2 is a zero Vector2(current flock agent is just on the center of circle).
        // 1 means current flock agent is just on the border of circle.
        var ratio = centerOffset.magnitude / radius;
        
        // Check if the current flock agent's position is in the circle area.
        if (ratio < 0.9f)
            return Vector2.zero;

        // If not or nearly not, then let current flock agent heading to the circle center direction.
        return centerOffset * (ratio * ratio);
    }
}
