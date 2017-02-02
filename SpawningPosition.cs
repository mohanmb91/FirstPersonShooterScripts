using UnityEngine;
using System.Collections;

public class SpawningPosition : MonoBehaviour {

	public SpawningPosition(){
		
	}

	public SpawningPosition(float newX, float newY, float newZ){
		this.x = newX;
		this.y = newY;
		this.z = newZ;
	}

	public float x;
	public float y;
	public float z;
	public float getX (){
		return this.x;
	}
	public float getY (){
		return this.y;
	}
	public float getZ (){
		return this.z;
	}
	public void setX(float newX){
		this.x = newX;
	}
	public void setY(float newY){
		this.y = newY;
	}
	public void setZ(float newZ){
		this.z = newZ;
	}
}
