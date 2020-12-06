using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    using Configs; 
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance; 
        public InputConfig KeyboardConfig; 
        public InputConfig ControllerConfig; 

        private void Awake() 
        {
            if (Instance != this && Instance != null)
                Destroy(this); 
            else 
                Instance = this; 
        }

        private void Update() 
        {
            // if (Input.GetKeyDown(KeyboardConfig.Interact) && KeyboardConfig.Interact != KeyCode.None || Input.GetKeyDown(ControllerConfig.Interact) && ControllerConfig.Interact != KeyCode.None)
                // EventManager.Instance.Interact(); 
            
            if (Input.GetKeyDown(KeyboardConfig.Jump) && KeyboardConfig.Jump != KeyCode.None || Input.GetKeyDown(ControllerConfig.Jump) && ControllerConfig.Jump != KeyCode.None)
                EventManager.Instance.Jump();
        }
    }

}

