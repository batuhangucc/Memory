using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 5, -10); 
    public bool lookAtTarget = true; 
    private void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 desiredPosition = target.position + offset;

           
            transform.position = desiredPosition;

            
            if (lookAtTarget)
            {
                transform.LookAt(target);
            }
        }
    }
}



