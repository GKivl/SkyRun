#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour {
    public float forwardBackwardForcePerSecond = 2000f;
    public float sidewaysForcePerSecond = 1500f;
    public float jumpForcePerSecond = 100f;
    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.W)) _rb.AddForce(Vector3.forward * (forwardBackwardForcePerSecond * Time.deltaTime));
        if (Input.GetKey(KeyCode.S)) _rb.AddForce(Vector3.forward * -(forwardBackwardForcePerSecond * Time.deltaTime));
        if (Input.GetKey(KeyCode.A)) _rb.AddForce(Vector3.left * (sidewaysForcePerSecond * Time.deltaTime));
        if (Input.GetKey(KeyCode.D)) _rb.AddForce(Vector3.right * (sidewaysForcePerSecond * Time.deltaTime));
    }

    private void OnCollisionStay(Collision other) {
        Debug.Log("Collision Stay");
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("JUMP");
            _rb.AddForce(Vector3.up * (jumpForcePerSecond * Time.deltaTime));
        }
    }
}