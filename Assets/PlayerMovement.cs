#region

using UnityEngine;
using UnityEngine.InputSystem;

#endregion

// Using simple actions with callbacks.
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;

    public InputAction moveAction;
    public InputAction lookAction;

    private Vector2 m_Rotation;

    public void Update() {
        // var look = lookAction.ReadValue<Vector2>();
        var move = moveAction.ReadValue<Vector2>();

        // Update orientation first, then move. Otherwise move orientation will lag
        // behind by one frame.
        // Look(look);
        Move(move);
    }


    public void OnEnable() {
        moveAction.Enable();
        lookAction.Enable();
    }

    public void OnDisable() {
        moveAction.Disable();
        lookAction.Disable();
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
        
    }
}