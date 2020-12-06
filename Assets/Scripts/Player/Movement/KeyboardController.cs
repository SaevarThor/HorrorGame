using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private KeyCode _interaction; 

    private void Update() 
    {
        if (Input.GetKeyDown(_interaction))
            MessageBus.SendMessage(MessageBus.MessageType.Interaction, true);     
    }
}
