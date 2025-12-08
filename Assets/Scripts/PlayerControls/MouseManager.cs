using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public static event Action<Vector3> OnMouseMove;
    public static event Action OnMouseClick;
    
    private Vector2 _pointerPosition;
    private bool _isPointerDown;
    private Camera _camera;


    [Header("Zoom parameters :")]
    [SerializeField] private float _minCameraZoom;
    [SerializeField] private float _maxCameraZoom;
    [SerializeField] private float _zoomSpeed;

    [Header("Side scrolling parameters :")]
    [SerializeField] private float _zoneScrollSize;
    [SerializeField] private float _scrollSpeed;


    private void Start()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        if (_isPointerDown)
        {
            Debug.Log("click");
        }
    }

    public void PointerPositionInputCallback(InputAction.CallbackContext context)
    {
        _pointerPosition = context.ReadValue<Vector2>();

        RaycastHit hit; ///RayCast from Camera
        Ray ray = _camera.ScreenPointToRay(_pointerPosition);



        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                OnMouseMove?.Invoke(hit.point);
                print(hit.point);
                Debug.Log($"objet touch� : {hit.collider.gameObject.name}");
            }
        }

        //// SCROLL SCREEN : 
        if (_pointerPosition.x <= _zoneScrollSize)  // Left
        {
            _camera.transform.position -= _camera.transform.right * _scrollSpeed;
        }

        if (_pointerPosition.x >= Screen.width - _zoneScrollSize) /// Right
        {
            _camera.transform.position += _camera.transform.right * _scrollSpeed;
        }

        if (_pointerPosition.y <= _zoneScrollSize) //Down 
        {
            _camera.transform.position -= _camera.transform.up * _scrollSpeed;
        }

        if (_pointerPosition.y >= Screen.height - _zoneScrollSize) // Up
        {
            _camera.transform.position += _camera.transform.up * _scrollSpeed;
        }
    }
       
    public void ClickCallBack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _isPointerDown = true;
            OnMouseClick?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            _isPointerDown = false;
        }
    }

    public void ScrollCallBack(InputAction.CallbackContext context)
    {
        float scrollValue = context.ReadValue<float>();

        if (_camera.orthographicSize < _minCameraZoom)
        {
            _camera.orthographicSize = _minCameraZoom;
        }
        else if (_camera.orthographicSize > _maxCameraZoom)
        {
            _camera.orthographicSize = _maxCameraZoom;
        }
        else if (_camera.orthographicSize >= _minCameraZoom && _camera.orthographicSize <= _maxCameraZoom)
        {
            if (scrollValue > 0)
            {
                _camera.orthographicSize -= _camera.orthographicSize * _zoomSpeed;
            }
            else if (scrollValue < 0)
            {
                _camera.orthographicSize += _camera.orthographicSize * _zoomSpeed;
            }
        }
    }

}


