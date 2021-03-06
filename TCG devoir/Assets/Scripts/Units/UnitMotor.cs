﻿using UnityEngine;
using System.Collections;

public class UnitMotor : MonoBehaviour {

	protected Animator animator;
	AnimatorStateInfo stateInfo;

	float moveMultip = 2;
	float idleTimeTemp;

	float xMin;
	float xMax;
	float yMin;
	float yMax;

	//variables a utiliser pour les cartes
	[HideInInspector]
	public Vector3 direction = Vector3.zero; //vecteur de déplacement d'un pion quelque soit son état
	public GameObject target; //Cible que le pion va suivre dans son Follow // Ne déclanche pas le state Follow


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		idleTimeTemp = animator.GetFloat ("idleTime");
		xMin = -24;
		xMax = 24;
		yMin = -36f;
		yMax = 37f;
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
				direction = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), 0).normalized;
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
				if (transform.position.y <= yMin) {
					direction.y = 1;
				} 
				else if (transform.position.y >= yMax) {
					direction.y = -1;
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
