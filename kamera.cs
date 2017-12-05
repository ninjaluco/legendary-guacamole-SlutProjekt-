﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
	public Vector3 offset;
	public GameObject player;

	// Use this for initialization
	void Start()
	{

		offset = transform.position - player.transform.position;
	}

	void Update()
	{
	

	}
	void LateUpdate()
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
		//transform.position = new Vector3(0, transform.position.y, -10);
		/*	transform.position = player.transform.position - offset * 2 * Time.deltaTime;*/ // First person :)
	}


}
