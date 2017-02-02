using UnityEngine;
using System.Collections;
public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;
	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
		StartCoroutine( waitBeforeDestroy (this.gameObject));
	}
	void OnTriggerEnter(Collider other) {
		PlayerCharacter player =
			other.GetComponent<PlayerCharacter>();
	if (player != null) {
			Messenger.Broadcast (GameEvent.PLAYER_HIT);
		}

		Destroy(this.gameObject);
	}

	IEnumerator waitBeforeDestroy(GameObject _fireball){
		yield return new WaitForSeconds(3.0f);
		if(_fireball != null){
			Destroy(_fireball);	
		}

	}
}