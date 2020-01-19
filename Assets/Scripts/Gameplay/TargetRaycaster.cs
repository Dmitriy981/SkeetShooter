using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Gameplay;
using UIEvents;
using UnityEngine;

public class TargetRaycaster : MonoBehaviour
{
    public event Action OnCollideStartedEvent; 
    public event Action OnCollideEndedEvent; 
    
    [SerializeField] private Camera _camera;
    [SerializeField] private int _targetLayer;
    [SerializeField] private float _radius;
    
    private bool _isCollideStarted;
    private GameObject _targetCollidedObject;

    public GameObject TargetCollidedObject => _targetCollidedObject;
    
    void Update()
    {
        RaycastHit[] hit = Physics.SphereCastAll(_camera.transform.position, _radius, _camera.transform.forward);

        int targetHitIndex = -1;
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.gameObject.layer == _targetLayer)
            {
                targetHitIndex = i;
                break;
            }
        }
        
        if (targetHitIndex >= 0)
        {
            if (!_isCollideStarted)
            {
                _targetCollidedObject = hit[targetHitIndex].transform.gameObject;
                OnStartCollide();
            }
        }
        else if (_isCollideStarted)
        {
            OnCollideEnded();
        }
    }

    private void OnStartCollide()
    {
        _isCollideStarted = true;
        OnCollideStartedEvent?.Invoke();
    }

    private void OnCollideEnded()
    {
        _targetCollidedObject = null;
        _isCollideStarted = false;
        OnCollideEndedEvent?.Invoke();
    }
}
