using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the ContextFilter class which represents same flock filter's behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Filter/SameFlockFilter")]
public class SameFlockFilter : ContextFilter
{

    public override List<Transform> FilterFlockAgent(FlockAgent currAgent, 
                                                     IEnumerable<Transform> originalAgentsTransforms)
    {
        // Store the filtered List of Transform of FlockAgent objects.
        var filteredTransformsList = new List<Transform>();
        // For each possible FlockAgent object's Transform in original Flock's FlockAgent object's Transform List.
        foreach (var flockAgentTransform in originalAgentsTransforms)
        {
            // Get this FlockAgent transform 's relative FlockAgent object.
            var flockAgent = flockAgentTransform.GetComponent<FlockAgent>();
            // Check if the relative flockAgent exist and belongs to the same flock like the current Flock Agent object.
            if (flockAgent != null && flockAgent.Flock == currAgent.Flock)
            {    
                // Then add this flockAgent's Transform to the final Transform List.
                filteredTransformsList.Add(flockAgentTransform);
            }
        }

        return filteredTransformsList;
    }
}
