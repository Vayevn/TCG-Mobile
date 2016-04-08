using UnityEngine;
using System.Collections;

public class UnitMotor : MonoBehaviour {

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	public float moveMultip = 2;
	float idleTimeTemp;


	public float xMin = -36.5f;
	public float xMax = 36.5f;
	public float zMin = -24f;
	public float zMax = 24f;


	//variables a utiliser pour les cartes
	[HideInInspector]
	public Vector3 direction = Vector3.zero;
	public GameObject target;


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		idleTimeTemp = animator.GetFloat ("idleTime");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.tag == "Player1Unit" || gameObject.tag == "Player2Unit") 
		{
			target = GetComponentInChildren<DetectionZone> ().target;
		}

		if (animator) 
		{
			//gestion du déplacement aléatoire
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

			else if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Follow")) 
			{
				direction = target.transform.position - transform.position;
				transform.position += direction * 2 * Time.deltaTime;
			} 
			if (target == null) 
			{
				animator.SetBool ("haveInRange", false);
			}
		}
	}
}
