using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour {

	// Use this for initialization


	
	
	// Update is called once per frame
	void Update () {
					if (Input.GetKey("escape"))
						Application.Quit();

		
	}
}


