using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil  {
	// this is a property
	// dictionary for objects that are created and recycled by spawner
	private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool> ();


	// add an obstacle
	public static GameObject Instantiate(GameObject prefab, Vector3 pos) {
		// store reference to instance
		GameObject instance = null;
		// pull from obstacles that have a recycle game object script
		var recycledScript = prefab.GetComponent<RecycleGameObject> ();
		if (recycledScript != null) {
			var pool = GetObjectPool (recycledScript);
			instance = pool.NextObject (pos).gameObject;
		} else {

			// if the obstacle or game object doesn't have a recycle game object script on it then create a new instance of it in the scene
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;

		}
			
		return instance;
	}

	// recycle the obstacle
	public static void Destroy (GameObject gameObject) {

		// test if the recycle game object script is attached to obstacle
		var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();

		if (recycleGameObject != null) {
			recycleGameObject.Shutdown ();
		} else {

		GameObject.Destroy (gameObject);
	
	}
}

	// get an obstacle and add it to the object pool
	private static ObjectPool GetObjectPool (RecycleGameObject reference)
	{
		ObjectPool pool = null;

		// code to access the dictionary

		if (pools.ContainsKey (reference)) {
			// key/value pair
			pool = pools[reference];

		} else {
			// if there is not pool then create it from scratch
			var poolContainer = new GameObject (reference.gameObject.name + "ObjectPool");
			pool = poolContainer.AddComponent<ObjectPool> ();
			pool.prefab = reference;
			pools.Add (reference, pool);
		}
		// return pool instance from dictionary or that was created from scratch
		return pool;
	}
}



