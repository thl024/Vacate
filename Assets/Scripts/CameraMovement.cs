using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Target;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CamMovement(Target);
        }
    }
    public void CamMovement(Transform inTarget)
    {
        transform.position = inTarget.position;
    }

}
