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
        if(Input.GetMouseButton(0))
        {
            Vector3 targetPos = Vector3.zero;
            targetPos.y = transform.position.y;

            Camera cam = Camera.main;               // Reference to main camera
            Vector3 mousePos = Input.mousePosition; // Mouse posistoin at the time of clicking

            Vector3 screenCenter = Vector3.zero;    // Finding the center of the screen
            screenCenter.x = Screen.width / 2;      //
            screenCenter.y = Screen.height / 2;     //

            mousePos = mousePos - screenCenter;     // Gets the click posistion relative to the center of the screens

            Vector3 clickAngle = Vector3.zero;          // Angle of the clicked posistion
            clickAngle.y = mousePos.y / screenCenter.y;
            clickAngle.x = mousePos.x / screenCenter.x;

            clickAngle.y *= (cam.fieldOfView * ((float)Screen.height / (float)Screen.width));
            clickAngle.x *= (cam.fieldOfView);

            Vector3 angleToClick = Vector3.zero;                                // Angle of the click to the object
            angleToClick = cam.transform.eulerAngles - transform.eulerAngles;   // relative to cameras rotation to the object
            angleToClick = angleToClick + clickAngle;                           // 

            float camHeight = 0.0f;                                         // Cameras height from the object
            camHeight = cam.transform.position.y - transform.position.y;    //

            print(clickAngle);
            clickAngle.x += cam.transform.position.x;
            clickAngle.y += cam.transform.position.y;
            clickAngle.z *= -1;

            clickAngle += cam.transform.eulerAngles;

            Debug.DrawRay(cam.transform.position, clickAngle * 10, Color.red);
        }
	}

}
