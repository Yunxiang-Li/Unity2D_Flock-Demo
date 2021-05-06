using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * An abstract class represents the flock's behavior which inherits the ScriptableObject class.
 */
public abstract class FlockBehavior : ScriptableObject
{
    /*
     * Calculate each current flock agent's next move according to all its neighbour flock agents' Transforms
     * and the Flock current flock agent belongs to.
     */
    public abstract Vector2 CalculateMove(FlockAgent currAgent, List<Transform> neighbourAgentsTransforms, Flock flock);
}
