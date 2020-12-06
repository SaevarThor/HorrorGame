using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRayFromCamera 
{
   public void CastRay(Camera playerCamera, float interactionRange, LayerMask interactionLayer ,out RaycastHit hit)
   {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        Physics.Raycast(ray, out hit ,interactionRange ,interactionLayer); 
   }
}
