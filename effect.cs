using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name == "mynt")
		{
			transform.Rotate(0, 0, 3);
		}
		if (gameObject.tag == "Capsule")
		{
		transform.Rotate(3, 0, 0);

		}
	}
}
