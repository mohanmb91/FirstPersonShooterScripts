using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	[SerializeField] private Camera main_camera;
	[SerializeField] private Camera third_person_camera;
	FPSInput main_input;
	RelativeMovement tps_Camera;
	public bool camera_switch = true;

	// Use this for initialization
	void Start () {
		main_input = this.GetComponent<FPSInput> ();
		tps_Camera = this.GetComponent<RelativeMovement> ();
		main_camera.gameObject.SetActive (true);
		third_person_camera.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("v")){
			camera_switch = !camera_switch;
		}
		if (camera_switch) {
			main_camera.gameObject.SetActive (true);
			main_input.enabled = true;

			third_person_camera.gameObject.SetActive (false);
			tps_Camera.enabled = false;
		} else {
			main_camera.gameObject.SetActive (false);
			main_input.enabled = false;

			third_person_camera.gameObject.SetActive (true);
			tps_Camera.enabled = true;
		}
	}
	public bool isFPS(){
		return this.camera_switch;
	}
}
