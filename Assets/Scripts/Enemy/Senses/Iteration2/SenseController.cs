using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseController : MonoBehaviour
{
    public ISense[] AllSenses; 

    private void Update() 
    {
        Sense();        
    }

    private void Sense()
    {    
        Vector3 target; 
        float reaction;  

        foreach(ISense sense in AllSenses)
        {
            if (sense.SensedTarget(out target, out reaction))
            {
                //Send as message for everyone to listen to. 
            }
        }
    }
}
