using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public Transform target;
	public float cameraDistance = 2;
	void FixedUpdate () 
	{
		transform.rotation = Quaternion.Slerp (transform.rotation, target.transform.rotation, 10f * Time.deltaTime);
		Vector3 forwardVector = transform.rotation * Vector3.back * cameraDistance;
		transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3 (0, 2.2f, 0) + forwardVector, 0.2f);
		transform.LookAt (target.position);
	}
}
