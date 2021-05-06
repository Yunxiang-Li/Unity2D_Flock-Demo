using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * An abstract class inherits from the ScriptableObject which represents filter behaviors.
 */
public abstract class ContextFilter : ScriptableObject
{
    // An abstract function that filter the input FlockAgent object to check if it belongs to the current flock.
    public abstract List<Transform> FilterFlockAgent(FlockAgent currAgent, 
                                                     IEnumerable<Transform> originalAgentsTransforms);
}
