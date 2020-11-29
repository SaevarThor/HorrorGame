using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;  

namespace Controller
{
    using Managers; 
    public class PlayerInteraction : MonoBehaviour
    {
        public Image CrosshairImage; 
        public Camera PlayerCamera; 
        public LayerMask InteractionLayer; 
        public string InteractionString = "Interactible"; 
        [Range(1,10)]
        public float InteractionRange = 2; 

        public void Start()
        {
            EventManager.OnInteraction += Interact; 
        }

        private void OnDisable() 
        {
            EventManager.OnInteraction -= Interact; 
        }

        void Update()
        {
            InteractVisual();
        }

        private void Interact(){
            Ray ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            print("Interact"); 

            if (Physics.Raycast(ray, out hit ,InteractionRange ,InteractionLayer))
            {
                print (hit.collider.name); 
                if (hit.collider.tag == InteractionString)
                    hit.collider.GetComponent<Interactible>().Use(); 
            } 
        }

        private void InteractVisual(){
            Ray ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        }
    }
}
