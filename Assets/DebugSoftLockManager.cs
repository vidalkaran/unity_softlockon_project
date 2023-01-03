using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSoftLockManager : MonoBehaviour
{
    Transform player;
    public SoftLockManager softLockManager;
    public bool inRange = false;
    public float dotProduct = 0;
    public float distance = 0;
    bool found = false;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        softLockManager = player.GetComponent<SoftLockManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        dotProduct = Vector3.Dot(player.transform.forward, transform.transform.forward);
        distance = Vector3.Distance(player.transform.position, transform.transform.position);

        found = false;
        foreach(Transform validTransform in softLockManager.validTargets)
        {
            if(validTransform == transform)
                found = true;
        }
        
        inRange = found ? true : false;

        if(inRange)
        {
            if(softLockManager.currentTarget == transform)
                mesh.material.color = Color.green;
            else
                mesh.material.color = Color.red;
        }
        else
            mesh.material.color = Color.white;
    }

}
