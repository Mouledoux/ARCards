/*  Eric Mouledoux 
 *  Eric@tantrumlab.com
 *  
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will Move whatever object has this component to the last position clicked in space
/// </summary>
public class WalkToClick : MonoBehaviour
{
    /// <summary>
    /// Speed at which the entity moves at
    /// </summary>
    [SerializeField] private float mSpeed;

    /// <summary>
    /// How far the entity can be from the object before stopping
    /// </summary>
    [SerializeField] private float mStoppingDistance;

    /// <summary>
    /// Posistion in 3d space of the last "click"
    /// </summary>
    private Vector3 mTargetPos;


	void Update ()
    {

	}
}
