﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the FlockBehavior class and represents each flock's avoidance behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    // Override CalculateMove method from FlockBehavior class.
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock)
    {
        // If no neighbours, Then keep the flock agent's original direction.
        if (neighbourAgentsTransforms.Count == 0)
            return Vector2.zero;

        // Initialize the avoidance move Vector2.
        var avoidanceMove = Vector2.zero;
        
        // Initialize the avoid number(how many neighbour flock agents are in avoidance radius).
        var avoidNum = 0;
        
        // Add each neighbour flock agent's position if it is inside current flock agent's avoidance circle area.
        foreach (var neighbourTransform in neighbourAgentsTransforms)
        {
            // Check if each neighbour flock agent is inside current flock agent's avoidance circle area.
            if (!(Vector2.SqrMagnitude(neighbourTransform.position - currAgent.transform.position)
                  < flock.getSquareAvoidanceRadius)) 
                continue;
            // If yes, increment the counter.
            ++avoidNum;
            // Handle each flock agent's offset vector.
            avoidanceMove += (Vector2)(currAgent.transform.position - neighbourTransform.position);
        }

        // Average the avoidance move.
        if (avoidNum > 0)
            avoidanceMove /= avoidNum;

        return avoidanceMove;
    }
}
