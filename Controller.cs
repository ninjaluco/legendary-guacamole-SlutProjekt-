using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{


	private Animator anim;
	public Rigidbody rb;
	public CapsuleCollider col;

	//Inställningar!
	public KeyCode moveL;
	public KeyCode moveR;
	public KeyCode jump;
	public bool controllLocked = false;
	public int laneNumber = 2;
	public bool IsGrounded;
	public float speed = 6.0f;
	public float gravity = 20.0f;
	public float jumpSpeed = 8.0f;
	public float horizon = 0;
	public float timeWait;
	public int laneLength;
	private Vector3 moveDir = Vector3.zero;

	public float lowJumpMulti = 60f;
	public Transform Explosion;


	// Use this for initialization
	void Start()
	{

		//StartCoroutine(startCouroutine(5f));
		anim = gameObject.GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();

	}



	// Update is called once per frame
	void Update()
	{
		CharacterController controller = GetComponent<CharacterController>();



		//if (controller.isGrounded)
		//{
		MovingFunction();

		if (IsGrounded == true)
		{
			Jumpinglogic();
		}
		if (Input.GetKey(moveL) && controllLocked == false && laneNumber > 1)
		{
			anim.Play("run_front@loop", -1, 0f);
			horizon = -2;
			StartCoroutine(StopSlide());
			laneNumber = laneNumber - 1;
			controllLocked = true;
		}
		else if (Input.GetKey(moveR) && controllLocked == false && laneNumber < 3)
		{
			anim.Play("run_front@loop", -1, 0f);
			horizon = 2;
			StartCoroutine(StopSlide());
			laneNumber = laneNumber + 1;
			controllLocked = true;
		}

		//}


		controller.Move(moveDir * Time.deltaTime);

	}


	private void Jumpinglogic()
	{
		if (Input.GetKeyDown(jump))
		{
			//anim.Play("run_front@loop", -1, 0f);
			//rb.AddForce(Vector3.up * lowJumpMulti, ForceMode.Impulse);

			moveDir.y = jumpSpeed;

		}
	}

	private IEnumerator StopSlide()
	{
		yield return new WaitForSeconds(.5f);
		horizon = 0;
		controllLocked = false;
	}

	private void MovingFunction()
	{
		moveDir = new Vector3(horizon * laneLength, 0, 1 * speed);
		moveDir = transform.TransformDirection(moveDir);
		//moveDir *= speed;
	}
	void OnCollisionStay(Collision collisionInfo)
	{
		IsGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		IsGrounded = false;
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Dödlig")
		{
			Destroy(gameObject);
			GM.hastighet = 0;
			Instantiate(Explosion, transform.position, Explosion.rotation);
			GM.klart = "död";
		}
		if (other.gameObject.tag == "Capsule")
		{
			Destroy(other.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "testkamera")
		{
			GM.vertVel = 2;
		}
		if (other.gameObject.name == "testkamerastop")
		{
			GM.vertVel = 0;
		}
		if (other.gameObject.name == "testkameraner")
		{
			GM.vertVel = -2;
		}
		if (other.gameObject.name == "hastKamera")
		{
			GM.hastighet = 2;
		}
		if (other.gameObject.name == "hastKameraNorm")
		{
			GM.hastighet = 4;
		}
		if (other.gameObject.name == "mynt")
		{
			Destroy(other.gameObject);
			GM.mynt += 1;
		}
		if (other.gameObject.tag == "Dödlig")
		{
			Destroy(gameObject);
			GM.hastighet = 0;
			Instantiate(Explosion, transform.position, Explosion.rotation);
			GM.klart = "död";
		}
	}
}
