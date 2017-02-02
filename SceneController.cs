
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Slider enemySpeed;
	private GameObject[] _enemy;
	int randomNo;
	public static int enemiesCount;
	[SerializeField] private GameObject player;
	public List<SpawningPosition> positions ;

	void Start(){
		InitializeSpwanPoint();
		enemiesCount = -1;
	}
	public Slider getEnemySlider(){
		return this.enemySpeed;
	}
	void Update() {
//		if(enemiesCount < 1){	
//		randomNo = Random.Range (1, 9);
//		this.setEnemyCount (randomNo);
//		_enemy = new GameObject[10];
//		for (int i = 0; i < randomNo; i++) {
//			_enemy [i] = Instantiate (enemyPrefab) as GameObject;
//				int tempRandomNo = Random.Range (0, 1);
//				_enemy [i].transform.position = new Vector3 (
//					positions[tempRandomNo].getX(),
//					positions[tempRandomNo].getY(),
//					positions[tempRandomNo].getZ()
//				);
//				_enemy [i].GetComponent<AvoidBlockAI> ().enemySpeedSlider = this.enemySpeed;
//				_enemy [i].GetComponent<AvoidBlockAI> ().player = this.player;
//			float angle = Random.Range (0, 360);
//			_enemy [i].transform.Rotate (0, angle, 0);    
//		}
//	}
	}
	public int getEnemyCount(){
		return enemiesCount;
	}
	public void setEnemyCount(int newEnemiesCount){
		enemiesCount = newEnemiesCount;
	}
	public void InitializeSpwanPoint(){
		positions.Add (new SpawningPosition (-106.0f, 0f ,429.0f));
//		positions.Add (new SpawningPosition (331.0f, 0.0f ,152.0f));
//		positions.Add (new SpawningPosition (200.0f, 0.0f ,341.0f));
//		positions.Add (new SpawningPosition (183.0f, 0.0f ,250.0f));
//		positions.Add (new SpawningPosition (271.0f, 2.0f ,134.0f));
	}
	public static void reduceEnemyCount(){
		enemiesCount -= 1;
	}

} 



