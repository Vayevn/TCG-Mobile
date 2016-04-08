using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public float currentLife;
	float maxLife = 3;

	void Start () {
		currentLife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentLife <= 0) {
			Destroy (this.gameObject);
		}
		//regeneration permanente

		if (currentLife < maxLife) {
			currentLife += Time.deltaTime;
		} else if (currentLife > maxLife)
			currentLife = maxLife;
	}
}
