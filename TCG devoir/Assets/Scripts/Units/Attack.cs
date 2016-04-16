using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	public GameObject target;
	public Vector3 direction = Vector3.zero;


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
			if (target == null) 
			{
				animator.SetBool ("onContact", false);
			}
			stateInfo = animator.GetCurrentAnimatorStateInfo (0);

			if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Attack")) 
			{
				target.GetComponent<Life> ().currentLife -= 2 * Time.deltaTime;
				direction = target.transform.position - transform.position;
				transform.position += direction * 2 * Time.deltaTime;
			}
		}
	}
}
