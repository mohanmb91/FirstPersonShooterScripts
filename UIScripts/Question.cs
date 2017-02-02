using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Question : MonoBehaviour {


	// Use this for initialization
	[SerializeField] private Image questionDialogueBox;
	[SerializeField] private Text question;
	[SerializeField] private Dropdown dropDownAnswers;
	[SerializeField] private Button submit;
	[SerializeField] private PlayerCharacter player;
	[SerializeField] private Image wrongDialogueBox;
	List<InitializeQuestion> questions;
	int currentQuestion;
	void Start () {
		generateQuestions ();
		disableQuestionnaire ();
		submit.onClick.AddListener(callOnSubmit);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void  callOnSubmit(){
		if ((this.dropDownAnswers.value).ToString() == "1") {
			if (this.GetComponent<UIController> ().getCurrentRoom () == "Room 1") {
				player.HotSpot1Teleport ();	
				this.GetComponent<UIController> ().setCurrentRoom ("Room 2");
			} else {
				player.HotSpot2Teleport ();	
				this.GetComponent<UIController> ().setCurrentRoom ("Room 1");
			}	
			Time.timeScale = 1.0F;
		} else {
			wrongDialogueBox.gameObject.SetActive (true);
		}

		disableQuestionnaire ();
	}
	void initializeQuestions(){
		int index = Random.Range (0, 8);
		this.setCurrentQuestionIndex (index);
		this.question.text = questions [index].getQuestion();
		this.dropDownAnswers.ClearOptions ();
		this.dropDownAnswers.AddOptions(questions [index].getOptions());

	}
	public void enableQuestionnaire(){
		Time.timeScale = 0F;
		initializeQuestions ();
		this.questionDialogueBox.gameObject.SetActive (true);
		this.question.gameObject.SetActive (true);
		this.dropDownAnswers.gameObject.SetActive (true);
		this.submit.gameObject.SetActive (true);
	}
	void disableQuestionnaire(){
		this.questionDialogueBox.gameObject.SetActive (false);
		this.question.gameObject.SetActive (false);
		this.dropDownAnswers.gameObject.SetActive (false);
		this.submit.gameObject.SetActive (false);
	}
	public void setQuestionDialogueBoxVisiblity(bool enable){
		this.questionDialogueBox.enabled = enable;
	}
	public int getCurrentQuestionIndex(){
		return this.currentQuestion;
	}
	public void setCurrentQuestionIndex(int index){
		 this.currentQuestion = index;
	}

	void generateQuestions(){
		questions = new List<InitializeQuestion> ();
		for (int i = 1; i < 10; i++) {
			InitializeQuestion eachQuestion = new InitializeQuestion ();
			eachQuestion.setQuestions (i + " + " + i + " = ?");
			List<string> options = new List<string> ();
			options.Add (i.ToString ());
			options.Add ((i + i).ToString ());
			options.Add ((i + i + i).ToString ());
			eachQuestion.setOptions (options);
			eachQuestion.setCorrectAnswer ((i + i).ToString ());
			questions.Add (eachQuestion);
		}
	}
}
