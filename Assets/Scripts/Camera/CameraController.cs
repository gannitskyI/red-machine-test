using Player;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraMovementConfig config;
    public Boundary boundary;

    private Vector3 _targetPosition;
    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _targetPosition = transform.position;
    }

    public void MoveCamera(Vector2 direction)
    { 
        if (PlayerController.PlayerState == PlayerState.Connecting)
            return;  

        _targetPosition += new Vector3(-direction.x, -direction.y, 0) * config.PanSpeed * Time.deltaTime;
        _targetPosition = boundary.ClampPosition(_targetPosition);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, config.SmoothTime);
    }
}
