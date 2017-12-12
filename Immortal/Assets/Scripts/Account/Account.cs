using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Account : ClientEntity {

	public override void OnCreated() {
		//this.CallServer ("Login", "100");
		if (SceneManager.GetActiveScene ().name != "Login") {
			SceneManager.LoadScene ("Login");
			return;
		}
		
		
	}

	public override void OnDestroy() {
		Debug.Log("Account is destroyed");
	}

	public void ShowInfo(string msg) {
        Debug.Log(msg);
	}

	public void ShowError(string msg) {
        Debug.Log(msg);
	}
}
