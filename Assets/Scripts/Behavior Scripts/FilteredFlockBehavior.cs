using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * An abstract class represents the flock's filtered behavior which inherits the ScriptableObject class.
 */
public abstract class FilteredFlockBehavior : FlockBehavior
{
    // Store a ContextFilter which used to filter specific items.
    public ContextFilter contextFilter;
}
