using UnityEngine;
using System.Collections;

public class UnitMotor : MonoBehaviour {

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	public float moveMultip = 2;
	float idleTimeTemp;

	public float xMin = -36f;
	public float xMax = 36f;
	public float zMin = -24;
	public float zMax = 24;

	//variables a utiliser pour les cartes
	[HideInInspector]
	public Vector3 direction = Vector3.zero; //vecteur de déplacement d'un pion quelque soit son état
	public GameObject target; //Cible que le pion va suivre dans son Follow // Ne déclanche pas le state Follow


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		idleTimeTemp = animator.GetFloat ("idleTime");
		xMin = -36f;
		xMax = 36f;
		zMin = -24;
		zMax = 24;
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
				//Debug.Log (direction);
				animator.SetFloat ("idleTime", animator.GetFloat("idleTime") - Time.deltaTime);
			}

			else if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Move"))
			{
				if (transform.position.x <= xMin) {
					direction.x = 1;
				}
				else if (transform.position.x >= xMax) {
					direction.x = -1;
				}
				if (transform.position.z <= zMin) {
					direction.z = 1;
				} else if (transform.position.z >= zMax) {
					direction.z = -1;
				}
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
