
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AIAssistant : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float followDistance = 1.0f;
    [SerializeField] private float followSpeed = 5.0f;

    private Transform headTransform;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        headTransform = Camera.main.transform;
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnSelectEntered);
        grabInteractable.onSelectExited.AddListener(OnSelectExited);
    }

    void Update()
    {
        // Follow the player at a specified distance and speed
        transform.position = Vector3.Lerp(transform.position, playerTransform.position - playerTransform.forward * followDistance, followSpeed * Time.deltaTime);
        transform.LookAt(headTransform);
    }

    void OnSelectEntered(XRBaseInteractor interactor)
    {
        // AI assistant can respond to player's requests
        Debug.Log("AI assistant: Hello! How can I assist you?");
    }

    void OnSelectExited(XRBaseInteractor interactor)
    {
        // AI assistant stops following the player when player releases it
        playerTransform = null;
    }

    public void SetPlayerTransform(Transform transform)
    {
        // Set the player transform for the AI assistant to follow
        playerTransform = transform;
    }
}
