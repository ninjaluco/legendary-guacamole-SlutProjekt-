using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOrb : MonoBehaviour
{
	public KeyCode moveL;
	public KeyCode moveR;
	public KeyCode jump;
	public int laneNum = 2;
	public string controllLocked = "n";

	public float lowJumpMulti = 60f;
	public bool IsGrounded;

	public Rigidbody rb;
	public SphereCollider col;

	public float horizont = 0;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		rb.GetComponent<Rigidbody>().velocity = new Vector3(horizont, 0, 4);
		col = GetComponent<SphereCollider>();

		Physics.gravity = new Vector3(0, -100.0F, 0);

		if (Input.GetKey(moveL) && (laneNum > 1) && (controllLocked == "n"))
		{
			horizont = -2;
			StartCoroutine(StopSlide());
			laneNum -= 1;
			controllLocked = "y";
		}
		else if (Input.GetKey(moveR) && (laneNum < 3) && (controllLocked == "n"))
		{
			horizont = 2;
			StartCoroutine(StopSlide());
			laneNum += 1;
			controllLocked = "y";
		}

		if (Input.GetKeyDown(jump) && IsGrounded)
		{
			rb.AddForce(Vector3.up * lowJumpMulti, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Dödlig")
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Capsule")
		{
			Destroy(other.gameObject);
		}
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		IsGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		IsGrounded = false;
	}
	IEnumerator StopSlide()
	{
		yield return new WaitForSeconds(.5f);
		horizont = 0;
		controllLocked = "n";
	}

}
