using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftTargetScript : MonoBehaviour
{
    public Transform currentTarget;
    public Collider[] validTargets;
    public int layerId = 0;
    public float detectionRange = 0;

    private LayerMask layerMask;

    void Start() => layerMask = (1 << layerId);

    void Update()
    {
        validTargets = Physics.OverlapSphere(transform.position, detectionRange, layerMask);

        if (validTargets.Length > 0)
        {
            foreach(Collider collider in validTargets)
            {
                if (currentTarget == null)
                    currentTarget = collider.transform;
                else if (Vector3.Distance(transform.position, collider.transform.position) < Vector3.Distance(transform.position, currentTarget.position))
                    currentTarget = collider.transform;
            }
        }
        else 
            currentTarget = null;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, detectionRange);
    }
}
