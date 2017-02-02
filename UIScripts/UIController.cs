using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLable;
	[SerializeField] private Text currentRoom;
	[SerializeField] private Slider slider;
	[SerializeField] private Question questionnaire;
	[SerializeField] private Scrollbar playerSpeedScrollBar;
	[SerializeField] private GameObject player; 
	[SerializeField] private GameObject myEnemy; 
	// Use this for initialization
	void Start () {
		currentRoom.text = "Room 1";
		slider.value = 5.0f;
		questionnaire = this.GetComponent<Question> ();
		playerSpeedScrollBar.onValueChanged.AddListener (delegate {
			playerSpeedChanged();	
		});
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		Messenger.AddListener (GameEvent.ENEMY_HIT,onEnemyDeath);
		Messenger.AddListener (GameEvent.ROOM_CHANGED,onChangeRoom);
		Messenger.AddListener (GameEvent.PLAYER_HIT,onPlayerHit);
		Messenger.AddListener (GameEvent.PLAYER_TOOK_HEALTH,onTakingHealth);
	}

	void playerSpeedChanged(){
		if (playerSpeedScrollBar.value <= 0.7f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (5.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (5.0f);
		} else if (playerSpeedScrollBar.value <= 0.21f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (6.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (6.0f);
		} else if (playerSpeedScrollBar.value <= 0.35f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (7.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (7.0f);
		} else if (playerSpeedScrollBar.value <= 0.49f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (8.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (8.0f);
		} else if (playerSpeedScrollBar.value <= 0.64f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (9.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (9.0f);
		} else if (playerSpeedScrollBar.value <= 0.78f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (10.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (10.0f);
		} else if (playerSpeedScrollBar.value <= 0.92f) {
			player.GetComponent<FPSInput> ().setPlayerSpeed (11.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (11.0f);
		} else {
			player.GetComponent<FPSInput> ().setPlayerSpeed (12.0f);
			player.GetComponent<RelativeMovement> ().setSpeedTPS (12.0f);
		}
	}
	void onPlayerHit(){
		if(this.getSlider() > 0.0f){
		this.setSlider (this.getSlider() - 1.0f);
			this.setSlider (this.getSlider() - 1.0f);
			PlayerCharacter player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerCharacter>();
			player.Hurt (1);
		}
	}
	void onTakingHealth(){
		if(this.getSlider() < 5.0f){
			this.setSlider (this.getSlider() + 1.0f);
			PlayerCharacter player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerCharacter>();
			player.consumedHealth ();

		}
	}
	void onEnemyDeath(){
		this.setScoreLable (this.getScoreLable() + 1);
	}

	void onChangeRoom(){
		questionnaire.enableQuestionnaire ();
	}

	public int getScoreLable(){
		return int.Parse(this.scoreLable.text);
	}

	public void setScoreLable(int newScore){
		this.scoreLable.text = newScore.ToString();
	}

	public string getCurrentRoom(){
		return this.currentRoom.text;
	}
	public void setCurrentRoom(string newScore){
		this.currentRoom.text = newScore;
	}

	public float getSlider(){
		return this.slider.value;
	}
	public void setSlider(float newSlider){
		this.slider.value = newSlider;
	}
}
