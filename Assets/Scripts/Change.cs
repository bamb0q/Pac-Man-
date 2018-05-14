using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour 
{
	public bool yes;
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.CompareTag ("Wall"))
		{
			yes = false;
			Debug.Log ("sciana: " + GetComponent<Collider> ().gameObject.name);
		} 
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Wall")) 
		{
			yes = true;
		}
	}
}
