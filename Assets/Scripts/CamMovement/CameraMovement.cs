using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    Transform Target;

    // Changes the camera transform to the target transform
    // TLDR; Moves the camera
    public void MoveCam(Transform inTarget) {
        transform.position = inTarget.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveCam(Target);
            Debug.Log(Target + " : " + Target.position.x + ", " + Target.position.y + ", " + Target.position.z);
        }
    }

}
