using UnityEngine;
public class Vision : MonoBehaviour, ISense
{
    [SerializeField] private Vector3Attribute _targetPosition; 
    [SerializeField] private string _targetTag; 
    [SerializeField] private VisionAttributes[] visionAttributes; 
    
    public bool SensedTarget(out int targetId, out int reactionStrength)
    {
        Vector3 targetLine = _targetPosition.RunTimeValue - transform.position; 
        float angle = Vector3.Angle(Vector3.forward, targetLine); 
        float distance = targetLine.magnitude; 

        foreach (VisionAttributes vision in visionAttributes)
        {
            if (angle > (vision.FieldOfView/ 2)) continue;
            if (distance > vision.ViewRange) continue; 

            targetId = 0; 
            reactionStrength = vision.ReactionStrength; 
            return(new CastRayFromObjectToTarget().TargetWasHit(transform, _targetPosition.RunTimeValue, _targetTag));
        }

        targetId = -1; 
        reactionStrength = 0; 
        return false; 
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(_targetPosition.RunTimeValue, transform.position);     
    }
}