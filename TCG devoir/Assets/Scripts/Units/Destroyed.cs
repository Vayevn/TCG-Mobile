using UnityEngine;
using System.Collections;

public class Destroyed : MonoBehaviour {

	public GameObject aggressor; //Game Object qui attaque le pion
	protected Animator animator;

	public GameObject player1Unit;
	public GameObject player2Unit;

	// Update is called once per frame
	void Start () 
	{
		animator = GetComponent<Animator> ();
	}

	void OnCollisionEnter (Collision other) 
	{
		aggressor = other.gameObject;
		animator.SetBool ("onContact", true);

	}

	void OnDestroy () 
	{
		if (gameObject.layer == 8) { //pion neutre
			if (aggressor.layer == 11) { //attaqué par pion rouge
				Instantiate (player1Unit, transform.position, transform.rotation);//convertion en pion rouge
			} 
			else if (aggressor.layer == 12 || aggressor.layer == 14) { //attaqué par pion bleu
				Instantiate (player2Unit, transform.position, transform.rotation);//convertion en pion bleu
			}
		} 
		else if (gameObject.layer == 11 && aggressor.layer == 14) //pion rouge qui change de couleur (carte de contrôle)
		{ 
			Instantiate (player2Unit, transform.position, transform.rotation);
		}
			
	}
}
