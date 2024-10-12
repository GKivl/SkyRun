#region

using UnityEngine;

#endregion

public class GameManager : MonoBehaviour {
    private GameObject _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void endGame() {
        Destroy(_player.transform.Find("PlayerArmature"));
    }

    public void test() {
        Debug.Log("testtt");
    }
}