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
    #region Vairables
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

    /// <summary>
    /// Current distance to the target position
    /// </summary>
    private float mDistanceToTarget;

    /// <summary>
    /// Referance to animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// If the object should be moving now.
    /// </summary>
    private bool canWalk;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        mTargetPos = transform.position;
        canWalk = false;
    }

    void Update()
    {
        if (canWalk)
        {
            transform.localPosition =
                new Vector3(transform.localPosition.x, 0, transform.localPosition.z);   // Makes sure that the object never leaves its plane


            if (Input.GetMouseButton(0))
            {
                float dist = Vector3.Distance(transform.position, Camera.main.transform.position);  // Distance to the main camera

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // Shoots a ray in the direction of the click
                mTargetPos = ray.origin + (ray.direction * dist);               // and sets the target to the return point

                mTargetPos.y = transform.position.y;    // Adjust the Y so its always flat

                animator.SetFloat("Speed", mSpeed);     // Walk there via animation
            }

            mDistanceToTarget = Vector3.Distance(transform.position, mTargetPos);

            if (mDistanceToTarget < mStoppingDistance)
            {
                animator.SetFloat("Speed", 0);
            }
            else
            {
                transform.LookAt(mTargetPos);           // Has this object look at the target position
                print("Look");
            }
        }
    }

    void OnBecameVisible()
    {
        canWalk = true;
    }

    void OnBecameInvisible()
    {
        canWalk = false;
    }
}
