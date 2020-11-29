using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "New Input", menuName = "Config/InputConfig", order = 0)]
    public class InputConfig : ScriptableObject 
    {
        public KeyCode Jump = KeyCode.Space; 
        public KeyCode Interact = KeyCode.E; 
        public KeyCode AltInterac = KeyCode.Q; 
        public KeyCode Crouch = KeyCode.LeftControl;
        public KeyCode AltCrouch = KeyCode.C; 
        public KeyCode Sprint = KeyCode.LeftShift; 
        public KeyCode AltSprint = KeyCode.LeftAlt;
        
    }   
}
