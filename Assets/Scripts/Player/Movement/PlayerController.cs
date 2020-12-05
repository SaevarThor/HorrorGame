using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Horror.Controller
{
	using Managers; 

	[RequireComponent(typeof(CharacterController))]
	public class PlayerController : MonoBehaviour 
	{
		[SerializeField] private FloatAttribute _walkSpeed;
		[SerializeField] private FloatAttribute _runSpeed; 
		[SerializeField] private FloatAttribute _jumpSpeed; 
		[SerializeField] private FloatAttribute _gravity; 
		[SerializeField] private Vector3Attribute _playerPosition; 
		private float _antiBumperFactor = .75f; 
		private int _antiBunnyHopFactor = 1; 
		private bool _limitDiagonalSpeed = true; 
		private bool ToggleRun; 

		//Private vars
		private Vector3 _moveDirection = Vector3.zero; 
		private Vector3 _contactPoint; 
		private bool _grounded; 
		private float _speed; 
		private float _slideLimit; 
		private float _rayDistance; 
		private int _jumpTimer; 
		private Transform _myTransform; 
		private CharacterController _controller; 
		private RaycastHit _hit; 


		// Use this for initialization
		void Start () {
			_controller = GetComponent<CharacterController> ();
			_myTransform = transform; 
			_speed = _walkSpeed.RunTimeValue; 
			_rayDistance = _controller.height * .5f + _controller.radius; 
			_slideLimit = _controller.slopeLimit - .1f; 
			_jumpTimer = _antiBunnyHopFactor; 

			EventManager.onJump += Jump; 
		}

		private void OnDisable() 
		{
			EventManager.onJump -= Jump; 	
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			float inputModifyFactor = (inputX != 0f && inputY != 0f && _limitDiagonalSpeed)? .7071f : 1f;

			if (inputY == 0 && inputX == 0)
			{
				_speed = _walkSpeed.RunTimeValue;  
			}
				
			if (_grounded)
			{
				if (!ToggleRun)
					_speed = Input.GetButton("Run")? _runSpeed.RunTimeValue : _walkSpeed.RunTimeValue;
				
				_moveDirection = new Vector3(inputX * inputModifyFactor, -_antiBumperFactor, inputY * inputModifyFactor); 
				_moveDirection = _myTransform.TransformDirection(_moveDirection) * _speed; 
				
				if (_jumpTimer >= _antiBunnyHopFactor)
				{
					_moveDirection.y = _jumpSpeed.RunTimeValue; 
					_jumpTimer = 0; 
				}
			}

			_moveDirection.y -= _gravity.RunTimeValue * Time.deltaTime; 
			_grounded = (_controller.Move(_moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;

			_playerPosition.RunTimeValue = this.transform.position; 
		}

		private void Jump()
		{
			if (!_grounded)
				return; 

			_jumpTimer++;
		}

		private void Update()
		{
			if (ToggleRun && _grounded && Input.GetButtonDown ("Run"))
				_speed = (_speed == _walkSpeed.RunTimeValue ? _runSpeed.RunTimeValue : _walkSpeed.RunTimeValue); 
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			_contactPoint = hit.point; 
		}


		public bool TestFloatInitalizer()
		{
			if (_walkSpeed == null || _runSpeed == null || _gravity == null || _jumpSpeed == null)
				return false; 
			else 
				return true; 
		}
	}
}
