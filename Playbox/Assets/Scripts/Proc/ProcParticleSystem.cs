using UnityEngine;
using System.Collections;

//using Particle = ParticleSystem.Particle; // Shortcut namespace

public class ProcParticleSystem : MonoBehaviour {

	public float gravity = -1f;
	private ParticleSystem myPS;

	void Start()
	{
		myPS = GetComponent<ParticleSystem> ();
	}

	void Update()
	{
		ParticleSystem.Particle[] myParticles = new ParticleSystem.Particle[myPS.particleCount];
		myPS.GetParticles (myParticles);

		for(int i = 0; i < myParticles.Length; ++i)
		{
			if(myParticles[i].position.y > 1f && myParticles[i].velocity.y > 0f ||
			   myParticles[i].position.y < -1f && myParticles[i].velocity.y < 0f)
			{
				Vector3 vel = myParticles[i].velocity;
				vel.y = -1f*vel.y;
				myParticles[i].velocity = vel;
			}
		}

		myPS.SetParticles (myParticles, myParticles.Length);
	}
}
