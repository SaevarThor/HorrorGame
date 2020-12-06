using System.Collections;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance; 
        public delegate void Jumping();
        public static event Jumping onJump;  

        private void Awake() 
        {
            if (Instance != this && Instance != null)
                Destroy(this); 
            else 
                Instance = this;    
        }

        public void Jump()
        {
            if (onJump != null)
                onJump();
        }
    }
}