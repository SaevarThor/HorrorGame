using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

namespace Controller
{ 
    public class PlayerInteraction : MonoBehaviour, IMessageReciever
    {
        [SerializeField] private Camera PlayerCamera; 
        [SerializeField] private LayerMask _interactionLayer; 
        [SerializeField] private string _interactionTag = "Interactible"; 
        [Range(1,10)]
        [SerializeField] private float _interactionRange = 2; 

        [Header("Visuals")]
        [SerializeField] private Image _crosshairImage; 
        [SerializeField] private Sprite _normalCrosshair; 
        [SerializeField] private Sprite _interactionCrosshair; 
        private CastRayFromCamera _visualRay;

        private void Awake() => MessageBus.Subscribe(MessageBus.MessageType.Interaction, this); 
        public void RecieveMessage<T>(T data) => Interact();
        

        void Update()
        {
            // InteractVisual();
        }

        public void Interact()
        {
            print ("Trying to interact"); 
            RaycastHit hit; 
            new CastRayFromCamera().CastRay(PlayerCamera, _interactionRange, _interactionLayer, out hit); 

            if (hit.transform == null) return; 

            try
            {
                if (hit.transform.CompareTag(_interactionTag))
                    hit.transform.GetComponent<IInteractible>().Interact();
            } 
            catch (Exception e)
            {
                Debug.LogError($"Attempting to interact with an object that doesnt conatin the IInteractible interface {e}"); 
            }
        }

        private void InteractVisual()
        {
            if (_visualRay == null)
                _visualRay = new CastRayFromCamera(); 

            RaycastHit hit; 

            _visualRay.CastRay(PlayerCamera, _interactionRange, _interactionLayer, out hit);

            _crosshairImage.sprite = hit.transform != null && hit.transform.CompareTag(_interactionTag) ? _interactionCrosshair : _normalCrosshair;    
        }

    }
}
