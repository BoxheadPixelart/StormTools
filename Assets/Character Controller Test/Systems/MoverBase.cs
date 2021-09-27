using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; 
using UnityEditor; 

namespace Storm.CharacterController
{


    public class MoverBase : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Rigidbody rb;
        [SerializeField] float liftForce;
       // [SerializeField] LayerMask layerMask;
       // [SerializeField] float maxLiftDist;
       // [SerializeField] float goalHeight;
       // [SerializeField] float springStrength;
       // [SerializeField] float springDamp;
       // [SerializeField] float uprightSpringStrength; 
       // [SerializeField] float uprightSpringDamp; 
        [SerializeField] Quaternion uprightTargetRot;
        [SerializeField] Vector3 raycastDir;
        [SerializeField] MoverData data; 
        Vector3 floorPos; 
        private void Awake()
        {
            rb = GetComponent<Rigidbody>(); 
        }
        void Start()
        {
            uprightTargetRot = Quaternion.Euler(transform.up);
            raycastDir = Vector3.down; 
        }
        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, raycastDir, out RaycastHit hit, data.maxLiftDist, data.layerMask))
            {
                Vector3 force = Vector3.up * liftForce;
                Vector3 otherVel = Vector3.zero;
                Vector3 rayDir = raycastDir;
                floorPos = hit.point; 
                float dist = hit.distance - data.goalHeight;
                float rayDirVel = Vector3.Dot(raycastDir, rb.velocity);
                float otherDirVel = Vector3.Dot(rayDir,otherVel); 
                float relVel = (rayDirVel - otherDirVel); 
                float springForce = (dist * (data.springStrength * rb.mass)) - (relVel * data.springDamp); 
                rb.AddForce(rayDir * (springForce), ForceMode.Force);
                
            }
            UpdateUprightForce();
        }

        void UpdateUprightForce()
        {
            Quaternion CharacterCurrent = transform.rotation;
            Quaternion toGoal = MathUtils.ShortestRotation(uprightTargetRot, CharacterCurrent);
            Vector3 rotAxis;
            float rotDegrees;
            toGoal.ToAngleAxis(out rotDegrees, out rotAxis);
            rotAxis.Normalize();
            float rotRadians = rotDegrees * Mathf.Deg2Rad;
            rb.AddTorque((rotAxis * (rotRadians * data.uprightSpringStrength)) - (rb.angularVelocity * data.uprightSpringDamp)); 
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {

            Vector3 endPos = transform.position + (raycastDir * data.maxLiftDist);

            Handles.color = Color.red;
            Vector3 drawPos = new Vector3(floorPos.x, floorPos.y + data.goalHeight, floorPos.z); 
            Handles.DrawSolidDisc(drawPos, Vector3.up,.5f);
            Handles.color = Color.green;
            Handles.DrawSolidDisc(floorPos, Vector3.up, .25f);
            Handles.color = Color.gray;
            Handles.DrawLine(transform.position, endPos);
            Handles.color = Color.white;
        }
#endif
    }


}
