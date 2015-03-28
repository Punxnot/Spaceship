
using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float rotationSpeed = 180f;

	public GameObject bullet;

	bool isWrappingX = false;
	bool isWrappingY = false;

	Renderer[] renderers;
	
	void Start()
	{
		renderers = GetComponentsInChildren<Renderer>();
	}
	
	bool CheckRenderers()
	{
		foreach(var renderer in renderers)
		{
			// If at least one render is visible, return true
			if(renderer.isVisible)
			{
				return true;
			}
		}
		
		// Otherwise, the object is invisible
		return false;
	}


	// Update is called once per frame
	void Update()
	{
		var horizontalAxis = Input.GetAxis("Horizontal");
		var verticalAxis = Input.GetAxis("Vertical");
		
		// Turn left or right on left/right buttons
		transform.Rotate(0, 0, -horizontalAxis * Time.deltaTime * rotationSpeed);
		
		// Move forward
		transform.Translate(Vector3.right * verticalAxis * Time.deltaTime * moveSpeed);

		var isVisible = CheckRenderers();

		// When the spacebar is pressed
		if (Input.GetKeyDown("space")) {
			
			//Instantiate(bullet, transform.position, Quaternion.identity);
			Instantiate(bullet, transform.position, Quaternion.AngleAxis(0, Vector3.forward) * transform.rotation);
			
		}
		
		if(isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}
		
		if(isWrappingX && isWrappingY) {
			return;
		}
		
		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;
		
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;
			
			isWrappingX = true;
		}
		
		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
		{
			newPosition.y = -newPosition.y;
			
			isWrappingY = true;
		}
		
		transform.position = newPosition;


		
	}
}