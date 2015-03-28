using UnityEngine;
using System.Collections;

public class AsteroidsController : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D bullet) {
		Destroy (gameObject);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
