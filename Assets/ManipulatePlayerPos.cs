using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatePlayerPos : MonoBehaviour
{
    public Vector3Attribute PlayerPosition;

    // Update is called once per frame
    void Update()
    {
        PlayerPosition.RunTimeValue = transform.position; 
    }
}
