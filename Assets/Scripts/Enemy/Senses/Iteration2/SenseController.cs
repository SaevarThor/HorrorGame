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
        if (AllSenses == null || AllSenses.Length == 0)
            AllSenses = GetComponents<ISense>();
        
        int targetId; 
        int reaction;  

        foreach(ISense sense in AllSenses)
        {
            print ("Has Sense and is searching"); 
            if (sense.SensedTarget(out targetId, out reaction))
            {
                print ("Sensed Target"); 
                //Send as message for everyone to listen to.
                AiSensoryMessage data = new AiSensoryMessage();
                data.SensoryStrength = reaction; 
                data.PlayerId = targetId; 

                MessageBus.SendMessage(MessageBus.MessageType.AiSensoryMessage, data);  
            }
        }
    }
}
