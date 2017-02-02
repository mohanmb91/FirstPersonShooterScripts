using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvoidBlockAI : MonoBehaviour {


	// Use this for initialization
	public GameObject myEnemy;
	public GameObject player;
	public Animator anim;
	public float distance;
	public float obstacleRange = 5.0f;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public bool is_Alive;
	public Slider enemySpeedSlider;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		enemySpeedSlider = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SceneController>().getEnemySlider();
		enemySpeedSlider.onValueChanged.AddListener (delegate {enemySpeedChanged();});
		this.setIsAlive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.getIsAlive ()) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		distance = myEnemy.GetComponent<LookAtPlayer> ().getDistance ();
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (!hitObject.GetComponent<PlayerCharacter> ()) {
				if (hit.distance < obstacleRange) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
					if(myEnemy.GetComponent<LookAtPlayer> ().getSpeed() == 0.0f){
						myEnemy.GetComponent<LookAtPlayer> ().setSpeed (this.enemySpeedSlider.value);
					}
			} else {

					if (distance < 8.0f) {
						myEnemy.GetComponent<LookAtPlayer> ().setSpeed (0f);
						this.anim.SetBool ("isRunning", false);
						this.anim.SetBool ("isWalking", false);
						this.anim.SetBool ("isAttacking", true);
						if (_fireball == null) {
							_fireball = Instantiate (fireballPrefab) as GameObject;
							if (player.transform.position.z - 5.0 < myEnemy.transform.position.z) {
								_fireball.transform.position = new Vector3 (myEnemy.transform.position.x, myEnemy.transform.position.y + 2.0f, myEnemy.transform.position.z - 1.5f);	
							} else {
								_fireball.transform.position = new Vector3 (myEnemy.transform.position.x, myEnemy.transform.position.y + 2.0f, myEnemy.transform.position.z + 1.5f);	
							}

							//_fireball.transform.position = myEnemy.transform.TransformPoint (Vector3.forward * 0.1f);
							_fireball.transform.rotation = myEnemy.transform.rotation;
						}
					} else {
						if(myEnemy.GetComponent<LookAtPlayer> ().getSpeed() == 0.0f){
							myEnemy.GetComponent<LookAtPlayer> ().setSpeed (this.enemySpeedSlider.value);
						}
					}
			}
		}
			if (myEnemy.GetComponent<LookAtPlayer> ().getSpeed () >= 5.0f && myEnemy.GetComponent<LookAtPlayer> ().getSpeed () < 8.0f) {
				this.anim.SetBool ("isRunning", false);
				this.anim.SetBool ("isAttacking", false);
				this.anim.SetBool ("isWalking", true);
			} else if(myEnemy.GetComponent<LookAtPlayer> ().getSpeed () > 8.0f){
				this.anim.SetBool ("isWalking", false);
				this.anim.SetBool ("isAttacking", false);
				this.anim.SetBool ("isRunning", true);
			}
	}
	}


	void enemySpeedChanged(){
		myEnemy.GetComponent<LookAtPlayer> ().setSpeed (this.enemySpeedSlider.value);
	}
	public void setIsAlive(bool isAlive){
		is_Alive = isAlive;
	}

	public bool getIsAlive(){
		return this.is_Alive;
	}
}
