using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitializeQuestion : MonoBehaviour {
 	
	string question;
	List<string> options;
	string correctAnswer;

	public void setQuestions(string newQuestion){
		this.question = newQuestion;
	} 
	public void setOptions(List<string> newOptions){
		this.options = newOptions;
	} 
	public void setCorrectAnswer(string newCorrectAnswer){
		this.correctAnswer = newCorrectAnswer;
	} 

	public string getQuestion(){
		return this.question;
	}
	public List<string> getOptions(){
		return this.options;
	}
	public string getCorrectAnswer(){
		return this.correctAnswer;
	}
}
