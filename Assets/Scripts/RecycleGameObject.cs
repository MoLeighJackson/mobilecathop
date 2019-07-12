using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle {
	// this interface is for recycling instances of obstacles from the object pool

	void Restart();
	void Shutdown();

}

public class RecycleGameObject : MonoBehaviour {

	//list of all components that implement Irecycle
	private List<IRecycle> recycleComponents;

	void Awake(){
		var components = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecycle> ();
		foreach (var component in components) {
			if (component is IRecycle) {
				recycleComponents.Add (component as IRecycle);
			}
		}
	
		// debug statement
		Debug.Log(name = " Found" + recycleComponents.Count + " Components");
	}


	public void Restart() {
		gameObject.SetActive (true);

		foreach (var component in recycleComponents) {
			component.Restart ();
		}		
	}

	public void Shutdown() {
		gameObject.SetActive (false);

		foreach (var component in recycleComponents) {
			component.Shutdown ();
		}		
	}
}
