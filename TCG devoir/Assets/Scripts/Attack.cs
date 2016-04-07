using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	public GameObject target;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	void OnCollisionEnter (Collision other) {
		target = other.gameObject;
		animator.SetBool ("onContact", true);
	}

	void OnCollisionExit (Collision other) {
		animator.SetBool ("onContact", false);
	}

	// Update is called once per frame
	void Update () {
		if (animator) {
			stateInfo = animator.GetCurrentAnimatorStateInfo (0);

			if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Attack")) 
			{
				target.GetComponent<Life> ().currentLife -= 2 * Time.deltaTime;

			}
		}
	}
}
