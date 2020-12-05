using UnityEngine;

public interface ISense
{
    bool SensedTarget(out Vector3 targetPos, out float rectionStrength);
}
