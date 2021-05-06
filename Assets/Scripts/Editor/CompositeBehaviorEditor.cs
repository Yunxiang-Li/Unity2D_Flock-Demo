using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * This class inherits form Editor class and represents an editor of flock's composite behavior.
 */
[CustomEditor(typeof(CompositeBehavior))]
public class CompositeBehaviorEditor : Editor
{
 /**
  * Implement this function to make a custom inspector.
  * Inside this function you can add your own custom IMGUI based GUI for the inspector of a specific object class.
  */
 public override void OnInspectorGUI()
 {
  // 1. Initialize the GUI.
  
  // target is the object being inspected.
  var cb = (CompositeBehavior) target;

  // 2. Check if behaviors do not exist.
  if (cb.behaviors == null || cb.behaviors.Length == 0)
  {
   // Output a warning message.
   EditorGUILayout.HelpBox("No behaviors", MessageType.Warning);
  }
  else
  {
   // Start a new rect row.
   EditorGUILayout.BeginHorizontal();
   // Adding the index field.
   EditorGUILayout.LabelField("Index", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
   // Adding the flock behaviors field.
   EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
   // Adding the Weights field.
   EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
   // End this rect row.
   EditorGUILayout.EndHorizontal();
 
   // Start to check if any changes are made.
   EditorGUI.BeginChangeCheck();
   
   // Set each kind of behavior's field.
   for (var i = 0; i < cb.behaviors.Length; i++)
   {
    // Start a new rect row for each kind of behavior.
    EditorGUILayout.BeginHorizontal();
    
    // Add each kind of behavior's label field.
    EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
    
    // Makes each behavior field(object).
    cb.behaviors[i] = (FlockBehavior)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(FlockBehavior),
     false, GUILayout.MinWidth(60f));
    
    // Makes each kind of behavior's weight field(float).
    cb.behaviorsWeights[i] = EditorGUILayout.FloatField(cb.behaviorsWeights[i], GUILayout.MinWidth(60f),
     GUILayout.MaxWidth(60f));
    
    // End each kind of behavior's rect row.
    EditorGUILayout.EndHorizontal();
   }
   
   // If any changes are made for GUI.
   if (EditorGUI.EndChangeCheck())
   {
    // Save the change.
    EditorUtility.SetDirty(cb);
   }
  }
  
  // Start a new rect for add behavior button.
  EditorGUILayout.BeginHorizontal();
  // make and check if user clicks the add behavior button.
  if (GUILayout.Button("Add Behavior"))
  {
   // Then call AddBehavior function to add one more behavior.
   AddBehavior(cb);
   // Save the change.
   EditorUtility.SetDirty(cb);
  }
  EditorGUILayout.EndHorizontal();

  // Check if at least one kind of behavior exists.
  if (cb.behaviors == null || cb.behaviors.Length <= 0) 
   return;
  // Start a new rect for remove behavior button.
  EditorGUILayout.BeginHorizontal();
  // make and check if user clicks the remove behavior button.
  if (GUILayout.Button("Remove Behavior"))
  {
   // Then call RemoveBehavior function to remove one exist behavior.
   RemoveBehavior(cb);
   // Save the change.
   EditorUtility.SetDirty(cb);
  }
  EditorGUILayout.EndHorizontal();
 }

 /**
  * Add one new field for one new behavior.
  */
 private void AddBehavior(CompositeBehavior cb)
 {
  // First check if new behavior array is not null and have at least one behavior.
  var oldCount = cb.behaviors?.Length ?? 0;
  // Create a new behavior array(one more length).
  var newBehaviors = new FlockBehavior[oldCount + 1];
  // Create a new float array(one more length).
  var newWeights = new float[oldCount + 1];
  
  // Assign previous behaviors and weights.
  for (var i = 0; i < oldCount; i++)
  {
   newBehaviors[i] = cb.behaviors[i];
   newWeights[i] = cb.behaviorsWeights[i];
  }
  
  // Set the new behavior's weight to 1f.
  newWeights[oldCount] = 1f;
  // Assign new behavior array and weight array back.
  cb.behaviors = newBehaviors;
  cb.behaviorsWeights = newWeights;
 }
 
 /**
  * Remove one exist field for one exist behavior.
  */
 private void RemoveBehavior(CompositeBehavior cb)
 {
  // Get exist behavior array's length.
  var oldCount = cb.behaviors.Length;
  
  // Check there is only one exist behavior.
  if (oldCount == 1)
  {
   // Set behavior array and weight array to null.
   cb.behaviors = null;
   cb.behaviorsWeights = null;
  }
  else
  {
   // Create a new behavior array(one less length).
   var newBehaviors = new FlockBehavior[oldCount - 1];
   // Create a new float array(one less length).
   var newWeights = new float[oldCount - 1];
   
   // Assign previous behaviors and weights unless the last behavior and weight.
   for (var i = 0; i < oldCount - 1; i++)
   {
    newBehaviors[i] = cb.behaviors[i];
    newWeights[i] = cb.behaviorsWeights[i];
   }
   // Assign new behavior array and weight array back.
   cb.behaviors = newBehaviors;
   cb.behaviorsWeights = newWeights;
  }
 }
}
