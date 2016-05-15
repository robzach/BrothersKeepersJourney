using UnityEngine;
using System.Collections;

public class mouseLook : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Input.GetAxis ("Mouse Y") * 2,0,0);
		transform.Rotate(0,Input.GetAxis ("Mouse X") * 2,0);
	}
}
