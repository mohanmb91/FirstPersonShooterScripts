using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {
	public GameObject[] weapons = new GameObject[1];
	// Use this for initialization
	void Start () {
		ActivateWeapon (1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			if (IsActiveWeapon (0)) {
				ActivateWeapon (1);
			} else {
				ActivateWeapon (0);
			}
		}
	}

	void ActivateWeapon(int i){
		foreach(GameObject eachWeapon in weapons){
			if(eachWeapon != weapons[i]){
				eachWeapon.SetActive (false);
			}
			if(eachWeapon == weapons[i]){
				eachWeapon.SetActive (true);
			}
		}
	}
	public string getActiveWeaponTagName(){
		foreach(GameObject eachWeapon in weapons){
			if (eachWeapon.activeSelf) {
				return eachWeapon.tag;
			}
		}
		return "";
	} 
	bool IsActiveWeapon(int i){
		return weapons [i].activeSelf;
	}
}
