using UnityEngine;

public class FloorUIArrowGuide : MonoBehaviour
{
    public Transform targetObject;
    public float arrowDistance = 1f;
    public float arrowSize = 0.1f;

    private Transform cameraTransform;
    private Vector3 arrowOffset;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        arrowOffset = new Vector3(0, 0.5f, 0);
    }

    void LateUpdate()
    {
        Vector3 targetPosition = targetObject.position;
        targetPosition.y = 0;
        transform.position = targetPosition + arrowOffset;
        transform.LookAt(targetObject.position);
    }
}
