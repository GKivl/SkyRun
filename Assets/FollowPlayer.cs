#region

using UnityEngine;

#endregion

public class FollowPlayer : MonoBehaviour {
    public Vector3 cameraOffset;
    public Transform PlayerTF;
    
    private void Update() {
        transform.position = PlayerTF.position + cameraOffset;
    }
}