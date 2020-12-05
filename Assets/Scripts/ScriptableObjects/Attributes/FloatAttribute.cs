using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFloatAttribute", menuName = "LavaPop/Attribute/Float")]
public class FloatAttribute : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue; 

    [NonSerialized] public float RunTimeValue;
 
    public void OnAfterDeserialize() => RunTimeValue = InitialValue; 

    public void OnBeforeSerialize(){}
}
