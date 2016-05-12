using UnityEngine;
using System.Collections;

public class Orders : MonoBehaviour {

	public GameObject mouseOver;
	public GameObject controlled;

	[HideInInspector]
	public int playerLayer = 14;
	public LayerMask _UnitLayer;



	void Update () {

		RaycastHit _Hit;
		Ray _Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (_Ray, out _Hit, _UnitLayer)) 
		{
			mouseOver = _Hit.transform.gameObject;	
		} 
		else 
		{
			mouseOver = null;
		}

		if (mouseOver.tag == "DetectZone")
			mouseOver = mouseOver.transform.parent.gameObject;


		if (Input.GetMouseButton (0) && mouseOver != null) 
		{
			controlled = mouseOver;
		} 
		if (Input.GetMouseButton (0) && mouseOver == null)
			controlled = null;


		if (Input.GetKey (KeyCode.A) && controlled.layer != playerLayer) //convert
		{
			controlled.GetComponent<Destroyed> ().aggressor = this.gameObject;
			controlled.GetComponent<Life> ().currentLife = 0;
		}
		else if (Input.GetKey (KeyCode.Z) && controlled.layer != playerLayer) //destroy
		{
			controlled.GetComponent<Destroyed> ().aggressor = null;
			controlled.GetComponent<Life> ().currentLife = 0;		
		}
		else if (Input.GetKey (KeyCode.E)) //attack
		{
			if (Input.GetMouseButtonDown (1) && mouseOver != null) 
			{
				controlled.GetComponent<Animator> ().SetBool ("underOrder", true);
				controlled.GetComponent<Attack> ().target = mouseOver;
			}
		}

		if (controlled.GetComponent<Attack> ().target == null)
			controlled.GetComponent<Animator> ().SetBool ("underOrder", false); //l'attaquant n'est plus sous l'ordre d'attaque imposé par le joueur
		
	}
}
