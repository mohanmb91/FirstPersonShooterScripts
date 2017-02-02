using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	[SerializeField] private GameObject bulletHole;
	public Texture2D crossHairImage;
	[SerializeField] public Light Flare;
	void Start() {
		_camera = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
		Flare.enabled = false;
	}

	void OnGUI() {
		//int size = 12;

		float posX = Screen.width/2 - crossHairImage.width/8;
		float posY = Screen.height/2 - crossHairImage.height/8;
		GUI.Label(new Rect(posX, posY, crossHairImage.width/4, crossHairImage.height/4), crossHairImage);
	}

	void Update() {
		Flare.enabled = false;
		if (Input.GetMouseButtonDown(0)) {
			Flare.enabled = true;
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
					Messenger.Broadcast (GameEvent.ENEMY_HIT);
				} else {
					//StartCoroutine(SphereIndicator(hit.point));
					StartCoroutine(SphereIndicator(hit));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(RaycastHit pos) {
		GameObject shape;
		//GameObject thePlayer = GameObject.FindWithTag("Player");
		//WeaponSwitching playerScript = this.GetComponent<WeaponSwitching>();
//		if (playerScript.getActiveWeaponTagName () == "Pistol") {
//			shape = GameObject.CreatePrimitive (PrimitiveType.Sphere);
//		} else {
//			shape = GameObject.CreatePrimitive (PrimitiveType.Cube);
//		}
		shape = Instantiate (bulletHole,pos.point,Quaternion.FromToRotation(Vector3.up,pos.normal)) as GameObject;

		yield return new WaitForSeconds(1);

		Destroy(shape);

	}
}