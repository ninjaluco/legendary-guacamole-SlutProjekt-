using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveGirl : MonoBehaviour
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
	public float speed = 6.0f;
	public float gravity = 20.0f;
	public float jumpSpeed = 8.0f;
	public float horizon = 0;
	public float timeWait;
	public int laneLength;
	private Vector3 moveDir = Vector3.zero;


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



		if (controller.isGrounded)
		{
			MovingFunction();
			Jumpinglogic();
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

		}	

		controller.Move(moveDir * Time.deltaTime);

	}

	private void Jumpinglogic()
	{
		if (Input.GetKey(jump))
		{
			anim.Play("run_front@loop", -1, 0f);
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
}
