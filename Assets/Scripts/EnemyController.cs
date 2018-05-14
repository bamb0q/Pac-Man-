using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public float speed = 5f;
	public float moveCooldown = 3f;
	public float startCooldown;
    float moveCooldownLeft = 0f;
	public GameObject Right;
	public GameObject Left;
	public GameObject Forward;
 	private Change right;
	private Change left;
	private Change forward;
	Vector3 initPos;

	public void Reset()
	{
		transform.position = initPos;
		transform.rotation = Quaternion.Euler (Vector3.zero);
		//startCooldown = 1f;

	}

	void Start () 
	{
		right = Right.GetComponent <Change> ();
		left = Left.GetComponent <Change> ();
		forward = Forward.GetComponent <Change> ();
		initPos = transform.position;
		moveCooldownLeft = moveCooldown;
		//startCooldown = 1f;
		Reset ();
	}

	void Update () 
	{
		System.Random ran = new System.Random ();
		int i = ran.Next (0, 4);
		startCooldown -= Time.deltaTime;
		moveCooldownLeft -= Time.deltaTime;

		if (startCooldown <= 0f) 
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
			if (moveCooldownLeft <= 0f) 
			{
				if (right.yes && !left.yes && !forward.yes) 
				{
					transform.Rotate (Vector3.up, 90f);
				} 
				else if (!right.yes && left.yes && !forward.yes) 
				{
					transform.Rotate (Vector3.up, -90f);
				} 
				else if (!right.yes && !left.yes && forward.yes) 
				{
					transform.Rotate (Vector3.up, 0f);
				} 
				else if (right.yes && left.yes && !forward.yes) 
				{
					if (i == 0 || i == 1)
						transform.Rotate (Vector3.up, 90f);
					else if (i == 2 || i == 3)
						transform.Rotate (Vector3.up, -90f);
				} 
				else if (right.yes && !left.yes && forward.yes) 
				{
					if (i == 0 || i == 1)
						transform.Rotate (Vector3.up, 90f);
					else if (i == 2 || i == 3)
						transform.Rotate (Vector3.up, 0f);
				} 
				else if (!right.yes && left.yes && forward.yes) 
				{
					if (i == 0 || i == 1)
						transform.Rotate (Vector3.up, -90f);
					else if (i == 2 || i == 3)
						transform.Rotate (Vector3.up, 0f);
				} 
				else if (right.yes && left.yes && forward.yes) 
				{
					if (i == 0)
						transform.Rotate (Vector3.up, 90f);
					else if (i == 1)
						transform.Rotate (Vector3.up, -90f);
					else if (i == 2 || i == 3)
						transform.Rotate (Vector3.up, 0f);
				}
				moveCooldownLeft = moveCooldown;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
				//transform.Rotate (Vector3.up, 180f);
				Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
		}
	}

	void  OnTriggerStay (Collider other)
	{
		if (other.gameObject.CompareTag ("Slower"))
		{
			speed = 2.5f;
			Debug.Log ("slower: " + GetComponent<Collider> ().gameObject.name);
		} 
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Slower"))
		{
			speed = 5f;
			Debug.Log ("slower exit: " + GetComponent<Collider> ().gameObject.name);
		} 
	}


}
