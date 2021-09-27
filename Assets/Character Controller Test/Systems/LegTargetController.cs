using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegTargetController : MonoBehaviour
{
    float raycastDist = 10; 
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform footTarget; 
    [SerializeField] Transform FollowTarget;
    [SerializeField] Vector3 positionOffset; 
    void Start()
    {
    raycastDist = 10;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit,raycastDist,layerMask))
        {
            footTarget.position = hit.point; 
        }
    }
}
