﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour {


	// Use this for initialization
	void start()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0, GM.vertVel, GM.hastighet);
	}

	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody>().velocity = new Vector3(0, GM.vertVel, GM.hastighet);
	}
}
