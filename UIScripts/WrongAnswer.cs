using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WrongAnswer : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Button submit;

	void Start () {
		this.gameObject.SetActive (false);
		submit.onClick.AddListener(callOnSubmit);
	}

	void callOnSubmit(){
		this.gameObject.SetActive (false);
		Time.timeScale = 1.0F;
	}
}
