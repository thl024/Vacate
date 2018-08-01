using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions  {

    public static void printTransform(Transform Target)
    {
        Debug.Log(Target + " : " + Target.position.x + ", " + Target.position.y + ", " + Target.position.z);
    }

   
	
}
