using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed = 3f;
	public float moveCooldown = 0.3f;
	public float startCooldown;
	float moveCooldownLeft = 0;
	private int count;
	public int lives = 3;
	public Text countText;
	public Text winText;
	public Text loseText;
	Animator anim;
	Vector3 initPos;
	public void Reset()
	{
		transform.position = initPos;
		transform.rotation = Quaternion.Euler (Vector3.zero);
		anim.SetBool ("IsWalking", false);
		startCooldown = 1f;
	}

	void Start()
	{
		count = 0;
		startCooldown= 1f;
		SetCountText ();
		winText.text = "";
		loseText.text = "";
		anim = GetComponent <Animator> ();
		initPos = transform.position;

		Reset ();
	}

	void FixedUpdate ()
	{
		startCooldown -= Time.deltaTime;
		moveCooldownLeft -= Time.deltaTime;
		bool walking = false;
		if (startCooldown <= 0) 
		{
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
				walking = true;
			} 
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (Vector3.back * speed * Time.deltaTime);
				walking = true;
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (Vector3.right * speed * Time.deltaTime);
				walking = true;
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector3.left * speed * Time.deltaTime);
				walking = true;
			} 
			else if(!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.W))
				walking = false;
			anim.SetBool ("IsWalking", walking);

			if (moveCooldownLeft <= 0) 
			{
				if (Input.GetKey (KeyCode.Q)) 
				{
					transform.Rotate(Vector3.up, -90f);
					moveCooldownLeft = moveCooldown;
				}

				if (Input.GetKey (KeyCode.E)) 
				{
					transform.Rotate(Vector3.up, 90f);
					moveCooldownLeft = moveCooldown;
				}
			}
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			lives -= 1;
			if (lives <= 0) {
				Destroy (this.gameObject);
				loseText.text = "GAME OVER";
			}
			Reset ();
		}
	}

	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
		if (count >= 252) 
		{
			winText.text = "YOU WIN";
		}
	}

}
