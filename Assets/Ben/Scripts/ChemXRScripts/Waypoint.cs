// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: 12/05/23
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/
using UnityEngine;
/// <summary>
/// Script to 
/// </summary>
public class Waypoint : MonoBehaviour
{
    public Transform targetObject;
    public float waypointDistance = 1f;
    public Waypoint nextWaypoint;

    private Transform cameraTransform;
    private Vector3 waypointOffset;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        waypointOffset = new Vector3(0, 0, waypointDistance);
    }

    void LateUpdate()
    {
        Vector3 targetPosition = targetObject.position;
        targetPosition.y += 1f; // adjust the height of the waypoint
        transform.position = targetPosition + waypointOffset;
        transform.LookAt(targetObject.position);

        // check if the player is close to the waypoint
        if (Vector3.Distance(cameraTransform.position, transform.position) < 0.5f)
        {
            // disable this waypoint and enable the next one
            gameObject.SetActive(false);
            if (nextWaypoint != null)
            {
                nextWaypoint.gameObject.SetActive(true);
            }
        }
    }
}
