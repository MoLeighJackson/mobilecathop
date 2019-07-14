using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputState : MonoBehaviour {

	// this script is for determining whether player is in motion or being stopped

	public bool actionButton;
	public float absVelX = 0f;
	public float absVelY = 0f;
	public bool standing;
	public float standingThreshold = 1;

	private Rigidbody2D body2d;

	//methods
	void Awake() {
		body2d = GetComponent<Rigidbody2D> ();
		
	}
	
	void Update () {
		actionButton = CrossPlatformInputManager.GetButtonDown ("Jump");
	}


	void FixedUpdate () {
	// check if the player is moving
		absVelX = System.Math.Abs (body2d.velocity.x);
		absVelY = System.Math.Abs (body2d.velocity.y);
	// check if the player is standing
		standing = absVelY <= standingThreshold;
	}
}
