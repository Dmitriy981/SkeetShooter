﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UIEvents;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IEventHandler
{
	[SerializeField] float _speedX = 2.0f;
	[SerializeField] float _speedY = 2.0f;

	[SerializeField] Vector2 _availableRotaionByX = new Vector2(-45f, 45f);
	[SerializeField] Vector2 _availableRotaionByY = new Vector2(-90f, 90f);

	private float _yRotation = 0.0f;
	private float _xRotation = 0.0f;

	private Vector3 _prevMousePosition;
	private bool _isDragging;
	
	private void Awake()
	{
		_xRotation = Clamp(transform.eulerAngles.x > 180.0f ?
			transform.eulerAngles.x - 360f : 
			transform.eulerAngles.x, _availableRotaionByX);
		
		_yRotation = Clamp(transform.eulerAngles.y > 180.0f ?
			transform.eulerAngles.y - 360f : 
			transform.eulerAngles.y, _availableRotaionByY);
	}

	private void OnEnable()
	{
		EventsManager.Instance.Subscribe(EventKeys.ControlDown, this);
		EventsManager.Instance.Subscribe(EventKeys.ControlUp, this);
	}

	private void OnDisable()
	{
		EventsManager.Instance.Unsubscribe(EventKeys.ControlDown, this);
		EventsManager.Instance.Unsubscribe(EventKeys.ControlUp, this);
	}

	private void Update()
	{
		if (_isDragging)
		{
			Vector3 direction = Input.mousePosition - _prevMousePosition;
			_yRotation -= _speedX * direction.x;
			_xRotation += _speedY * direction.y;
			
			_prevMousePosition = Input.mousePosition;
			
			_xRotation = Clamp(_xRotation, _availableRotaionByX);
			_yRotation = Clamp(_yRotation, _availableRotaionByY);

			transform.rotation = Quaternion.Euler(new Vector3(_xRotation, _yRotation, 0.0f));
		}
	}

	public void OnEvent(string eventKey, params object[] pars)
	{
		switch (eventKey)
		{
			case EventKeys.ControlDown:
				OnPointerDown();
				break;
			
			case EventKeys.ControlUp:
				OnPointerUp();
				break;
		}
	}

	private float Clamp(float value, Vector2 borders)
	{
		return Mathf.Clamp(value, borders.x, borders.y);
	}

	private void OnPointerDown()
	{
		_isDragging = true;
		_prevMousePosition = Input.mousePosition;
	}

	private void OnPointerUp()
	{
		_isDragging = false;
	}
}
