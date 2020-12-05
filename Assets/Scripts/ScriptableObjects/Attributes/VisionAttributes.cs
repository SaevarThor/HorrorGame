using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vision Profile", menuName = "LavaPop/Profiles/VisionProfile")]
public class VisionAttributes : ScriptableObject
{
    public float ViewRange;
    public float FieldOfView; 
    public int ReactionStrength; 
}
