using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntAttribute", menuName = "LavaPop/Attribute/Int")]
public class IntAttribute : ScriptableObject, ISerializationCallbackReceiver
{
    public int InitialValue; 

    [NonSerialized] public float RunTimeValue;

    public void OnAfterDeserialize() => RunTimeValue = InitialValue; 

    public void OnBeforeSerialize(){}
}
