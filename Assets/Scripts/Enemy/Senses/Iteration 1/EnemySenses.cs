using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{
    public enum States
    {
        Hunting,
        Hiding,
        Searching,
        Attacking
    }

    [SerializeField] private Vector3Attribute _playersPosition; 
    [SerializeField] private Camera _mainCamera; 
    [SerializeField] private Collider _collider; 

    [Header ("Main Vision")]
    [SerializeField] private FloatAttribute _mainVisionDistance; 
    [SerializeField] private FloatAttribute _mainFieldOfView; 
    // [SerializeField] private FloatAttribute _mainTimeUntilSeen; 
    
    [Header ("Peripheral Vision")]
    [SerializeField] private FloatAttribute _peripheralVisionDistance; 
    [SerializeField] private FloatAttribute _peripheralFieldOfView; 
    // [SerializeField] private FloatAttribute _peripheralTimeUntilSeen; 

    [Header ("Tunnel Vision")]
    [SerializeField] private FloatAttribute _tunnelVisionDistance; 
    [SerializeField] private FloatAttribute _tunnelFieldOfView; 
    // [SerializeField] private FloatAttribute _tunnelTimeUntilSeen; 

    private bool _inMainVision;
    private bool _inPeripheralVision; 
    private bool _inTunnelVision; 
    private bool _seenByPlayer; 

    private void Vision()
    {
        _inMainVision = CastVision(_mainFieldOfView.RunTimeValue, _mainVisionDistance.RunTimeValue); 
        _inPeripheralVision = CastVision(_peripheralFieldOfView.RunTimeValue, _peripheralVisionDistance.RunTimeValue); 
        _inTunnelVision = CastVision(_tunnelFieldOfView.RunTimeValue, _tunnelVisionDistance.RunTimeValue); 

        _seenByPlayer = IsVisible();
    }

    private bool CastVision(float fieldOfView, float maxDistance)
    {
        Vector3 playerLine = _playersPosition.RunTimeValue - transform.position; 
        float angle = Vector3.Angle(Vector3.forward, playerLine); 
        float distance = playerLine.magnitude; 

        RaycastHit hit; 

        if (angle < (fieldOfView / 2) && distance <= maxDistance)
            if (Physics.Linecast(transform.position, _playersPosition.RunTimeValue, out hit))
                return hit.collider.tag == "Player"; 
        
        return false;
    }

    private bool IsVisible()
    {
        Plane[] frustrumPlane = GeometryUtility.CalculateFrustumPlanes(_mainCamera); 

        if (GeometryUtility.TestPlanesAABB(frustrumPlane, _collider.bounds))
        {
            RaycastHit hit; 
            if (Physics.Linecast(_playersPosition.RunTimeValue, transform.position, out hit))
                return hit.collider.tag == "Enemy"; 
        }
        return false;
    }
}
