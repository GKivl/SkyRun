#region

using UnityEngine;
using UnityEngine.InputSystem;

#endregion

// Use a separate PlayerInput component for setting up input.
public class TheController : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;

    private Vector2 _look;
    private Vector2 _move;
    private Vector2 _rotation;

    public void Update() {
        // Update orientation first, then move. Otherwise, move orientation will lag
        // behind by one frame.
        Look(_look);
        Move(_move);
    }

    public void OnMove(InputAction.CallbackContext context) {
        _move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) {
        _look = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction) {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }

    private void Look(Vector2 rotate) {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        _rotation.y += rotate.x * scaledRotateSpeed;
        _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = _rotation;
    }
}