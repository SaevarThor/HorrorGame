using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3 Attribute", menuName = "LavaPop/Attribute/Vector3")]
public class Vector3Attribute : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector3 InitialValue;
    [NonSerialized] public Vector3 RunTimeValue; 
    
    public void OnAfterDeserialize() => RunTimeValue = InitialValue; 

    public void OnBeforeSerialize(){}
}
