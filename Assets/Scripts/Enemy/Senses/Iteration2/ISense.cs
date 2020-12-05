using UnityEngine;

public interface ISense
{
    bool SensedTarget(out int targetId,  out int rectionStrength);
}
