using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("j"))
		{
			SceneManager.LoadScene("Plan");
		}
		GetComponent<TextMesh>().text = "Mynt : " + GM.mynt;
	}
}
