using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
	public class CameraController: MonoBehaviour {
		[SerializeField] private FloatAttribute _smoothing; 
		[SerializeField] private FloatAttribute _sensitivity; 
		[SerializeField] private FloatAttribute _controllerSensitivityHorizontal; 
		[SerializeField] private FloatAttribute _controllerSensitivityVertical; 
		[SerializeField] private FloatAttribute _controllerSmoothing; 
		[SerializeField] private FloatAttribute _controllerDeadZone; 
		private Vector2 _mouseLook; 
		private Vector2 _smoothV; 
		private GameObject _playerObject; 

		// Use this for initialization
		void Start () {
			_playerObject = this.transform.parent.gameObject; 
		}
		
		// Update is called once per frame
		void Update () {
			// float controllerInputX = Input.GetAxisRaw("CameraHorizontal"); 
			// float controllerInputY = Input.GetAxisRaw("CameraVertical"); 
			
			// if (controllerInputX == 0 && controllerInputY == 0)
			// {
				var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y")); 

				md = Vector2.Scale (md, new Vector2 (_sensitivity.RunTimeValue * _smoothing.RunTimeValue, _sensitivity.RunTimeValue * _smoothing.RunTimeValue)); 
				_smoothV.x = Mathf.Lerp (_smoothV.x, md.x, 1 / _smoothing.RunTimeValue); 
				_smoothV.y = Mathf.Lerp (_smoothV.y, md.y, 1 / _smoothing.RunTimeValue); 

				_mouseLook += _smoothV; 
				_mouseLook.y = Mathf.Clamp (_mouseLook.y, -90, 90); 
			// } else 
			// {

				// Vector2 controllerInputs = new Vector2(controllerInputX, controllerInputY); 
				// var cameraMovement = Vector2.Scale (controllerInputs, new Vector2(_controllerSensitivityHorizontal.RunTimeValue * _controllerSmoothing.RunTimeValue, _controllerSensitivityVertical.RunTimeValue * _controllerSmoothing.RunTimeValue)); 

				// _smoothV.x = Mathf.Lerp(_smoothV.x, cameraMovement.x, 1 / _controllerSmoothing.RunTimeValue); 
				// _smoothV.y = Mathf.Lerp(_smoothV.y, cameraMovement.y, 1 / _controllerSmoothing.RunTimeValue); 

				// _mouseLook += _smoothV; 
				// _mouseLook.y = Mathf.Clamp(_mouseLook.y, -90,90); 
			// }

			transform.localRotation = Quaternion.AngleAxis (-_mouseLook.y, Vector3.right); 
			_playerObject.transform.localRotation = Quaternion.AngleAxis (_mouseLook.x, _playerObject.transform.up);
		}
	}
}