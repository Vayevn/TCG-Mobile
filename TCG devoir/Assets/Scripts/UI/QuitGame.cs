using UnityEngine;

public class QuitGame : MonoBehaviour {

	public void QuitGameNow(){

		//if not saved
		//do you want to save your player files ?

		print("Quit !");
		Application.Quit();

	}

}
