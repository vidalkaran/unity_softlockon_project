using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSoftTargetScript : MonoBehaviour
{
    public SoftTargetScript softTargetScript;
    public bool inRange = false;
    bool found = false;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start() => mesh = GetComponent<MeshRenderer>();

    // Update is called once per frame
    void Update()
    {
        found = false;
        foreach(Collider collider in softTargetScript.validTargets)
        {
            if(collider.transform == transform)
                found = true;
        }
        
        inRange = found ? true : false;

        if(inRange)
        {
            if(softTargetScript.currentTarget == transform)
                mesh.material.color = Color.green;
            else
                mesh.material.color = Color.red;
        }
        else
            mesh.material.color = Color.white;
    }
}
