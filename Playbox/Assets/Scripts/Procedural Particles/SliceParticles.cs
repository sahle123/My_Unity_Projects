/*	
 * 	SliceParticles.cs
 * 	Author: Julien Lynge
 * 	Date:	Nov. 12th, 2014
 * 
 */

using UnityEngine;
using System.Collections;

public class SliceParticles : MonoBehaviour {

	public ParticleSystem ps = null;
	public float disturbRadius = 1f;
	public float velocityMultiplier = 1f;

	private Vector3 mousePosition;

	void Start()
	{
		mousePosition = getMousePositionAtParticleSystem ();

		StartCoroutine (checkMouseMovement ());
	}

	// Determine delta mouse position and set particles
	IEnumerator checkMouseMovement()
	{
		while(true)
		{
			Vector3 newPosition = getMousePositionAtParticleSystem();
			Vector3 delta = newPosition - mousePosition;
			mousePosition = newPosition;

			SetParticles(delta, mousePosition);

			yield return new WaitForSeconds(0.05f);
		}
	}

	// Project the mouse with a ray onto the plane of the particle system to get its position
	private Vector3 getMousePositionAtParticleSystem()
	{
		Vector3 mousePos = Input.mousePosition;

		// Project the mouse position and evelocity onto the plane of the particle system.
		Ray mouseRay = camera.ScreenPointToRay (mousePos);
		Plane plane = new Plane (transform.forward, ps.transform.position); // <- Don't really understand this.
		float distance;
		plane.Raycast (mouseRay, out distance);

		// Where the ray hits the plane, we have our position.
		mousePos = mouseRay.GetPoint (distance);
		Debug.Log ("Distance is " + distance + ", point is " + mousePos);
		return mousePos;
	}

	private void SetParticles(Vector3 mouseVelocity, Vector3 mousePosition)
	{
		// Get particles
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];
		int particleCount = ps.GetParticles (particles);

		// Change particles
		for(int i = 0; i < particleCount; ++i)
		{
			float distance = Vector3.Distance (mousePosition, particles[i].position);
			if(distance < disturbRadius)
				particles[i].velocity += mouseVelocity * (1f - (distance / disturbRadius)) * velocityMultiplier;
		}

		// Set the particles
		ps.SetParticles (particles, particleCount);
	}

}
