using UnityEngine;
using System.Collections;

public class DetectionZone : MonoBehaviour {

	protected Animator animator;

	public GameObject target;

	void Start () 
	{
		animator = GetComponentInParent<Animator>();
		animator.SetBool ("haveInRange", false);
	}

	void OnTriggerEnter(Collider other) {

		if (animator) {
			if (animator. GetBool ("havenRange") == false) {
				animator.SetBool ("haveInRange", true);
				target = other.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (animator) 
		{
			animator.SetBool ("haveInRange", false);
			target = other.gameObject;
		}
	}
}
