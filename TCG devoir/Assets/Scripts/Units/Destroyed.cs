using UnityEngine;
using System.Collections;

public class Destroyed : MonoBehaviour {

	public GameObject aggressor; //Game Object qui attaque le pion
	protected Animator animator;

	private bool onQuit = false;

	public GameObject player1Unit;
	public GameObject player2Unit;

	// Update is called once per frame
	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnCollisionEnter (Collision other) {
		aggressor = other.gameObject;
		animator.SetBool ("onContact", true);

	}

	void OnDestroy () {
		if (!onQuit) 
		{
			aggressor.GetComponent<Animator> ().SetBool ("onContact", false);
		}
		if (gameObject.layer == 8) //neutral unit
		{ 
			if (aggressor.layer == 11) //player 1 unit
			{ 
				Instantiate (player1Unit, transform.position, transform.rotation);
			} else if (aggressor.layer == 12) //player2 unit
			{ 
				Instantiate (player2Unit, transform.position, transform.rotation);
			}
		}
	}

	void OnApplicationQuit() {
		onQuit = true;
	}
}
