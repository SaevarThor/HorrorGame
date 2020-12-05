using UnityEngine;

public class CastRayFromObjectToTarget
{
   public bool TargetWasHit(Transform caster, Vector3 targetPosition, string targetTag)
   {
        RaycastHit hit; 
        if (Physics.Linecast(caster.position, targetPosition, out hit))
        {
            return hit.transform.CompareTag(targetTag); 
        }
        else
        {
            return false; 
        }
   }
}
