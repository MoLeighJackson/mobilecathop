using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IRecycle {
	// array of sprites
	public Sprite[] sprites;
	public Vector2 colliderOffset = Vector2.zero;

	public void Restart () {
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites [Random.Range (0, sprites.Length)];
	
		// make box collider the size of the sprite
		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += colliderOffset.y;

		collider.size = size;
		collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
	
	}
	

	public void Shutdown () {
		
	}
}
