using UnityEngine;
using System.Collections;

public class UnitMotor : MonoBehaviour {

	public float moveMultip = 2;
	public Vector3 direction = Vector3.zero;

	private float idleTimeTemp;

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		idleTimeTemp = animator.GetFloat ("idleTime");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (animator) 
		{
			stateInfo = animator.GetCurrentAnimatorStateInfo (0);
			if (animator.IsInTransition (0)) 
			{
				animator.SetFloat ("idleTime", idleTimeTemp);
			}

			if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Idle"))
			{
				animator.SetFloat ("moveTime", Random.value + moveMultip);
				direction = new Vector3 (Random.Range (-1.0f, 1.0f), 0, Random.Range (-1.0f, 1.0f)).normalized;
				Debug.Log (direction);
				animator.SetFloat ("idleTime", animator.GetFloat("idleTime") - Time.deltaTime);
			}

			else if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Move"))
			{
				transform.position += direction * 2 * Time.deltaTime;
				animator.SetFloat ("moveTime", animator.GetFloat("moveTime") - Time.deltaTime);
			}
		}
	}
}
