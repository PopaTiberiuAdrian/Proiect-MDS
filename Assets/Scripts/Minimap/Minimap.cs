using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    [SerializeField]Transform playerTransform;
    Vector3 playerPositionAuxilliary;
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90f, playerTransform.eulerAngles.y, 0f);
        playerPositionAuxilliary.x = playerTransform.position.x;
        playerPositionAuxilliary.z = playerTransform.position.z;
        playerPositionAuxilliary.y = transform.position.y;
        transform.position = playerPositionAuxilliary;
    }
}
