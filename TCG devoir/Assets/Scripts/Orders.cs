using UnityEngine;
using System.Collections;

public class Orders : MonoBehaviour {

	public GameObject controlled;

	[HideInInspector]
	public int playerLayer = 14;
	public LayerMask _UnitLayer;

	void Update () {

		RaycastHit _Hit;
		Ray _Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (_Ray, out _Hit, _UnitLayer)) 
		{
			controlled = _Hit.transform.gameObject;	
		} else 
		{
			controlled = null;
		}
		if (controlled.tag == null)
			controlled = controlled.transform.parent.gameObject;


		if (Input.GetMouseButton (0) && (controlled != null)) 
		{
			if (Input.GetKey (KeyCode.A) && (controlled.layer != playerLayer)) 
			{
				controlled.GetComponent<Destroyed> ().aggressor = this.gameObject;
				controlled.GetComponent<Life> ().currentLife = 0;
			}
		}
	}
}
