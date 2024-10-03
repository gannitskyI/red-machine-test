using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public CameraController cameraController;

    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool _isDragging = false;

    void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    { 
        if (PlayerController.PlayerState == PlayerState.Connecting)
            return; 

        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _startTouchPosition = Input.mousePosition;
        }

        if (_isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                _currentTouchPosition = Input.mousePosition;
                Vector2 swipeDelta = _currentTouchPosition - _startTouchPosition;

                if (swipeDelta.magnitude > 10)
                {
                    cameraController.MoveCamera(swipeDelta);
                    _startTouchPosition = _currentTouchPosition;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }
    }
}
