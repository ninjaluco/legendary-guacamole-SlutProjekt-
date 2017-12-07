using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public static float vertVel = 0;
	public static float hastighet = 4;
	public static int mynt = 0;
	public float laddar = 0;
	public static string klart = "";
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update () {
		
		if (klart  == "död")
		{
			laddar += Time.deltaTime;
		}
		if (laddar > 1)
		{
			SceneManager.LoadScene("Tavla");
		}
	}
}
