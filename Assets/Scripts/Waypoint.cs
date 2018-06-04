using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
   
    public bool WaypointMesh(bool enableDisable)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = enableDisable;
        return enableDisable;
    }
	
	void Start () {
        WaypointMesh(false);
	}
	
}
