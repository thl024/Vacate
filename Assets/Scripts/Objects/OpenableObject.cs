using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableObject : InteractableObject {

	public OpenableObjectState state;

}

public enum OpenableObjectState {
	Open,
	Close
}