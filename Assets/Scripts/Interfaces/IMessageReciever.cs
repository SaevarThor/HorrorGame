using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMessageReciever  
{
    void RecieveMessage<T>(T data);
}
