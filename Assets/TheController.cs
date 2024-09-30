#region

using UnityEngine;
using UnityEngine.InputSystem;

#endregion

// Use a separate PlayerInput component for setting up input.
public class TheController : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;

    public InputAction moveAction;
    public InputAction lookAction;
    
    private Rigidbody _rb;
    private Vector3 _moveVector = Vector3.zero;
    private Vector2 _lookVector = Vector2.zero;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }
    void OnEnable() {
        moveAction.Enable();
        lookAction.Enable();
    }

    void OnDisable() {
        moveAction.Disable();
        lookAction.Disable();
    }

    void Update() {
        _moveVector = moveAction.ReadValue<Vector3>();
        _lookVector = lookAction.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        _rb.velocity = _moveVector * (moveSpeed * Time.deltaTime);
    }
    
}