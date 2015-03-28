using UnityEngine;
using System.Collections;

public class AsteroidsController : MonoBehaviour {

	public GameObject bullet;
	public float tumble;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().angularVelocity = Random.value * tumble;

		GetComponent<Rigidbody2D>().position = new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-5.0F, 5.0F));
	}

	void OnCollisionEnter2D(Collision2D bullet) {
		Destroy (gameObject);
	}


	// Update is called once per frame
	void Update () {

	}
}
