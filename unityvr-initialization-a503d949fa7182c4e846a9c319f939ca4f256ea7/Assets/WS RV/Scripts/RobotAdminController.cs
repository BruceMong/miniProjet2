using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class RobotAdminController : MonoBehaviour
{
    public GameObject head;
    public float jumpForce = 5f;

    public Rigidbody headRigidbody;
    public NavMeshAgent agentNavRobot;
    public FireController fireController;
    public XRGrabInteractable grabInteractable;


    public void SetSpeed(float speed)
    {
        agentNavRobot.speed = speed;
    }

    void Start()
    {
        headRigidbody = head.GetComponent<Rigidbody>();
        headRigidbody.isKinematic = true; // Empêche la tête de tomber immédiatement
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DetachAndJumpHead();
        }
    }

    void DetachAndJumpHead()
    {
        if (head.transform.parent != null)
        {
            fireController.ToggleFire();
            grabInteractable.enabled = true;

            head.transform.parent = null; // Détache la tête du corps
            headRigidbody.isKinematic = false; // Active la physique
            headRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Ajoute une force pour faire sauter la tête
            SetSpeed(0);
        }
    }
}
