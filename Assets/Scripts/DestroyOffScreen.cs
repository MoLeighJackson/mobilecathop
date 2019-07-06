﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

	public float offset = 16f;

	private bool offscreen;
	private float offscreenX = 0;
	private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Start () {
		offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}

	void Update () {
		var posX = transform.position.x;
		var dirX = body2d.velocity.x;

		if(Mathf.Abs(posX) > offscreenX) {

			if(dirX < 0 && posX < -offscreenX) {
				offscreen = true;
			} else if (dirX > 0 && posX > offscreenX) {
				offscreen = true;
			}
		} else {
			offscreen = false;
		}
		if (offscreen) {
			OnOutOfBounds ();
		}
}

	public void OnOutOfBounds() {
		offscreen = false;
		GameObjectUtil.Destroy (gameObject);
	}
}