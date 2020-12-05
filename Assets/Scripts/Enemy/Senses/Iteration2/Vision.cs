using UnityEngine;
public class Vision : MonoBehaviour, ISense
{
    private CastRayFromObjectToTarget _ray; 
    [SerializeField] private Vector3Attribute _targetPosition; 
    [SerializeField] private string _targetTag; 
    [SerializeField] private VisionAttributes[] visionAttributes; 
    
    public bool SensedTarget(out Vector3 targetPos, out float reactionStrength)
    {
        Vector3 targetLine = _targetPosition.RunTimeValue - transform.position; 
        float angle = Vector3.Angle(Vector3.forward, targetLine); 
        float distance = targetLine.magnitude; 
        

        foreach (VisionAttributes vision in visionAttributes)
        {
            if (angle > (vision.FieldOfView/ 2)) continue;
            if (distance > vision.ViewRange) continue; 

            targetPos = _targetPosition.RunTimeValue; 
            reactionStrength = vision.ReactionStrength; 
            return(_ray.TargetWasHit(transform, _targetPosition.RunTimeValue, _targetTag));
        }

        targetPos = Vector3.zero; 
        reactionStrength = 0; 
        return false; 
    }
}