using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Changes the camera transform to the target transform
    // TLDR; Moves the camera
    public void MoveCam(Transform inTarget) {
        transform.position = inTarget.position;
    }

}
