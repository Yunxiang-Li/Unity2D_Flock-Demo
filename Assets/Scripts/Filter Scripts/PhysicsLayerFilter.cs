using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class inherits from the ContextFilter class which represents physics layer filter's behaviors.
 */
[CreateAssetMenu(menuName = "Flock/Filter/PhysicsLayerFilter")]
public class PhysicsLayerFilter : ContextFilter
{
    // A GameObject can use up to 32 LayerMasks supported by the Editor.
    // The first 8 of these Layers are specified by Unity, the following 24 are controllable by the user.
    public LayerMask layerMask;

    public override List<Transform> FilterFlockAgent(FlockAgent currAgent, 
                                                     IEnumerable<Transform> originalAgentsTransforms)
    {
        // Store the filtered List of Transform of FlockAgent objects.
        var filteredTransformsList = new List<Transform>();
        // For each possible FlockAgent object's Transform in original Flock's FlockAgent object's Transform List.
        foreach (var flockAgentTransform in originalAgentsTransforms)
        {
            // 1 << flockAgentTransform.gameObject.layer means get the current flock agent's layer.
            // Check if current flock agent's layer is the same layer as layerMask.
            if (layerMask == (layerMask | (1 << flockAgentTransform.gameObject.layer)))
            {
                // Then no need for collision handle, just add to the filtered List.
                filteredTransformsList.Add(flockAgentTransform);
            }
        }

        return filteredTransformsList;
    }
}
