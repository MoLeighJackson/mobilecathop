using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 2.0f;
	public bool active = true;
	public Vector2 delayRange = new Vector2(1, 2);

	// Use this for initialization
	void Start () {
		
		StartCoroutine (ObstacleGenerator ());
	}

	IEnumerator ObstacleGenerator(){

		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;

			Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);
		
		}

		StartCoroutine (ObstacleGenerator ());

	}


}
