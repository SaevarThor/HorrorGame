using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttributes : MonoBehaviour, IMessageReciever
{
    public IntAttribute _playerSensed;

    public void RecieveMessage<T>(T data)
    {
        AiSensoryMessage incomingMessage = data as AiSensoryMessage; 
        _playerSensed.RunTimeValue += incomingMessage.SensoryStrength; 

        Debug.Log($"Recieved message with sensed increase of {incomingMessage.SensoryStrength} and updating player sensed to {_playerSensed.RunTimeValue}"); 
    }

    private void Awake() =>
        MessageBus.Subscribe(MessageBus.MessageType.AiSensoryMessage, this);
    
}
