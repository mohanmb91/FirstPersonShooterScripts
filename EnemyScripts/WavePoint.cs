using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WavePoint : MonoBehaviour 
{
	public List<Transform> Waypoints;
	Transform CurrentWP;
	public bool isAlive = true;
	public float SpeedMovement;
	int CurrentWPNumber;
	public float AlertDistance;
	public Transform PlayerObj;
	public float ShootInterval;

	private float f;

	public GameObject Bullet;
	public Transform SpawnPoint;
	public float BulletSpeed;
	//public GameObject enemy;

	void Start ()
	{
		CurrentWPNumber = 0;
		CurrentWP = Waypoints [CurrentWPNumber];
	}

	void Update () 
	{
		if(isAlive){
		if (Vector3.Distance (transform.position, PlayerObj.position) > AlertDistance) 
		{
			transform.position = Vector3.MoveTowards (transform.position, CurrentWP.position, SpeedMovement * Time.deltaTime);
			transform.LookAt (CurrentWP.position);
			Stop_Shooting ();
			this.GetComponent<Animator>().SetBool("isRunning", false);
			this.GetComponent<Animator>().SetBool("isWalking", true);
			this.GetComponent<Animator>().SetBool("isAttacking",false);
			this.GetComponent<Animator>().SetBool ("isDead", false);
		}
		else 
		{
				
			Start_Shooting ();
			transform.LookAt (PlayerObj.position);
			follow ();
			this.GetComponent<Animator>().SetBool("isRunning", false);
			this.GetComponent<Animator>().SetBool("isWalking", false);
			this.GetComponent<Animator>().SetBool("isAttacking",true);
			this.GetComponent<Animator>().SetBool ("isDead", false);
		}
		}

	}

	public void setEnemyDead(){
		this.isAlive = false;
	}

	void Start_Shooting()
	{
		f += Time.deltaTime;

		if (f >= ShootInterval) 
		{
			f = 0;
			Shoot_Bullet ();
		}
	}

	void Stop_Shooting()
	{

	}

	void follow(){
		transform.Translate (Vector3.forward * SpeedMovement * Time.deltaTime);
		this.GetComponent<Animator>().SetBool("isRunning", true);
		this.GetComponent<Animator>().SetBool("isWalking", false);
		this.GetComponent<Animator>().SetBool("isAttacking",false);
		this.GetComponent<Animator>().SetBool ("isDead", false);
	}
	void Shoot_Bullet()
	{
		GameObject GO = Instantiate (Bullet, SpawnPoint.position, SpawnPoint.rotation) as GameObject;
		GO.GetComponent<Fireball> ().speed = BulletSpeed;
		GO.transform.LookAt (PlayerObj.position);
	}

	void OnTriggerEnter(Collider C)
	{
		//print ("Entered");
		if (C.gameObject.name.Contains ("wp1")) 
		{
			//print (C.gameObject.name);
			CurrentWPNumber++;

			if (CurrentWPNumber == Waypoints.Count) 
			{
				CurrentWPNumber = 0;
			}

			CurrentWP = Waypoints [CurrentWPNumber];
		}
	}
}