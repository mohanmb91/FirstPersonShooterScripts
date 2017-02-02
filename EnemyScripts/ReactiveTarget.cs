using UnityEngine;
using System.Collections;
public class ReactiveTarget : MonoBehaviour {

	[SerializeField] public GameObject healthPackPreFab;
	private GameObject healthPack;
	public Animator anim;
	public void Start(){
		anim = GetComponent<Animator> ();
	}

	public void ReactToHit() {
//		// Check if this character has a WanderingAI script
//		AvoidBlockAI behavior = this.GetComponent<AvoidBlockAI>();
//		if (behavior != null) {

			StartCoroutine(Die());
//			behavior.setIsAlive(false);
//		}

	}
	private IEnumerator Die() {
		this.anim.SetBool("isRunning", false);
		this.anim.SetBool("isWalking", false);
		this.anim.SetBool("isAttacking",false);
		this.anim.SetBool ("isDead", true);
		this.GetComponent<WavePoint>().setEnemyDead();
		yield return new WaitForSeconds(4.0f);
		healthPack = Instantiate (healthPackPreFab, this.transform.position,this.transform.rotation) as GameObject;
		Destroy(this.gameObject);

		SceneController.reduceEnemyCount ();
	}
}