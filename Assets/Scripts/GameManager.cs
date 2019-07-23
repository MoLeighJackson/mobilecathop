using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;

	//properties that don't show up in inspector
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;

	// methods
	void Awake () {
		// get instances of the floor and spawner
		floor = GameObject.Find ("Floor");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
	}
		

	void Start () {

		// position floor at the bottom and center of screen
		var floorHeight = floor.transform.localScale.y;

		var pos = floor.transform.position;
		pos.x = 0;
		// get bottom of the screen from the screen's center point
		pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) * (floorHeight/2);
		// set position to floor's current tranform position
		floor.transform.position = pos;
		// deactivate the spawner
		spawner.active = false;

		ResetGame ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnPlayerKilled() {
		spawner.active = false;

	}

	void ResetGame() {
	
		spawner.active = true;
		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2, 0));

		var playerDestroyScript = player.GetComponent<DestroyOffScreen> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;
	}



}
