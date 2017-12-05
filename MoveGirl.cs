//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class MoveGirl : MonoBehaviour
//{
//	public KeyCode moveL;
//	public KeyCode moveR;
//	public KeyCode jump;
//	public int laneNum = 2;
//	public string controllLocked = "n";

//	public float lowJumpMulti = 60f;
//	public bool IsGrounded;

//	public Rigidbody rb;
//	public SphereCollider col;

//	public float horizont = 0;
//	public Animator anim;
//	// Use this for initialization
//	void Start()
//	{
//		anim = GetComponent<Animator>();
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		rb.GetComponent<Rigidbody>().velocity = new Vector3(horizont, 0, 4);
//		col = GetComponent<SphereCollider>();

//		Physics.gravity = new Vector3(0, -100.0F, 0);

//		if (Input.GetKey(moveL) && (laneNum > 1) && (controllLocked == "n"))
//		{
//			anim.Play("run_left@loop", -1, 0f);
//			horizont = -2;
//			StartCoroutine(StopSlide());
//			laneNum -= 1;
//			controllLocked = "y";
//		}
//		else if (Input.GetKey(moveR) && (laneNum < 3) && (controllLocked == "n"))
//		{
//			anim.Play("run_right@loop", -1, 0f);

//			horizont = 2;
//			StartCoroutine(StopSlide());
//			laneNum += 1;
//			controllLocked = "y";
//		}

//		if (Input.GetKeyDown(jump) && IsGrounded)
//		{
//			anim.Play("run_front@loop", -1, 0f);

//			rb.AddForce(Vector3.up * lowJumpMulti, ForceMode.Impulse);
//		}
//	}
//	void OnCollisionEnter(Collision other)
//	{
//		if (other.gameObject.tag == "Dödlig")
//		{
//			Destroy(gameObject);
//		}
//		if (other.gameObject.tag == "Capsule")
//		{
//			Destroy(other.gameObject);
//		}
//	}

//	void OnCollisionStay(Collision collisionInfo)
//	{
//		IsGrounded = true;
//	}

//	void OnCollisionExit(Collision collisionInfo)
//	{
//		IsGrounded = false;
//	}
//	IEnumerator StopSlide()
//	{
//		yield return new WaitForSeconds(.5f);
//		horizont = 0;
//		controllLocked = "n";
//	}
//}
