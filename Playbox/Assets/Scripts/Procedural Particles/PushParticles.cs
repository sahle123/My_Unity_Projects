/*
 * 	PushParticles.cs
 * 	Author: Julien Lynge
 * 	Date:	Nov. 12th, 2014
 * 
 */

using UnityEngine;
using System.Collections;

public class PushParticles : MonoBehaviour {

	public ParticleSystem ps = null;

	void Update()
	{
		if(Input.GetKey (KeyCode.Space))
		{
			// Set up a timer
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			timer.Start ();

			// Get the particles
			ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];
			// We can also construct the array above using ps.particleCount, intead of suppling 1000
			// i.e. ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
			int particleCount = ps.GetParticles (particles);

			// Change the particles
			for(int i = 0; i < particleCount; ++i)
			{
				particles[i].velocity += new Vector3(-0.1f, 0, 0);
			}

			// Set the particles
			ps.SetParticles (particles, particleCount);

			// Debug some info
			timer.Stop ();
			Debug.Log("It took: " + timer.ElapsedMilliseconds + "ms to change " + 
			          particleCount + " particles in frame " + Time.frameCount);
		}
	}
}
