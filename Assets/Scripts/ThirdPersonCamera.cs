using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    Player localPlayer;
	// Use this for initialization
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
	}
	
    void HandleOnLocalPlayerJoined (Player player)
    {
        localPlayer = player;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
