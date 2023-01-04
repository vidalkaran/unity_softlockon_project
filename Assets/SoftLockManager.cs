using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftLockManager : MonoBehaviour
{
    public Transform currentTarget;
    public List<Transform> validTargets;
    public int layerId = 0;
    public float detectionRange = 0; // Radius around the player where we wanna check // Length the of the cone
    [Range(0, -1)]
    public float dotThreshold = 0; // How wide the cone goes 

    private LayerMask layerMask;
    private Collider[] targetInRange;

    void Start()
    {
        validTargets = new List<Transform>();
        layerMask = (1 << layerId);
    }

    void Update()
    {
        targetInRange = Physics.OverlapSphere(transform.position, detectionRange, layerMask);
        validTargets.Clear();
        currentTarget = null;

        // Priority by centerline
        if (targetInRange.Length > 0)
        {
            foreach(Collider collider in targetInRange)
            {
                if(Vector3.Dot(transform.forward, collider.transform.forward) <= dotThreshold)
                    validTargets.Add(collider.transform);
            }
        }

        // Priority by distance
        foreach(Transform target in validTargets)
        {
            if (currentTarget == null)
                currentTarget = target;

            if(Vector3.Distance(transform.position, target.position) < Vector3.Distance(transform.position, currentTarget.position))
            {
                currentTarget = target;
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, detectionRange);
    }
}
