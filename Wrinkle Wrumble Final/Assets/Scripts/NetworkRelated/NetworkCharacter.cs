using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition2 = Vector3.zero;
	Vector3 rigidbodyVel = Vector3.zero;
	Vector3 rigidbodyAngVel = Vector3.zero;
	Quaternion realRotation2 = Quaternion.identity;

	Animator anim;
	bool gotFirstUpdate = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(anim == null) {
			Debug.LogError ("ZOMG, you forgot to put an Animator component on this character prefab!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( photonView.isMine ) {
			// Do nothing -- the character motor/input/etc... is moving us
		}
		else {

			GetComponent<Rigidbody>().position = Vector3.Lerp(GetComponent<Rigidbody>().position, realPosition2, 0.1f);
			GetComponent<Rigidbody>().velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, rigidbodyVel, 0.1f);
			GetComponent<Rigidbody>().rotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, realRotation2, 0.1f);
			
			GetComponent<Rigidbody>().angularVelocity = Vector3.Lerp(GetComponent<Rigidbody>().angularVelocity, rigidbodyAngVel, 0.1f);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if(stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.

			stream.SendNext(anim.GetFloat("Speed"));
			stream.SendNext(anim.GetFloat("Rotation"));
			stream.SendNext(anim.GetBool("Ground"));
			stream.SendNext(anim.GetFloat("vSpeed"));
			stream.SendNext(anim.GetFloat("Strafe"));
			stream.SendNext(anim.GetBool("Dead"));
			stream.SendNext(anim.GetBool("Throw"));
			stream.SendNext(anim.GetBool("Push"));

			stream.SendNext(GetComponent<Rigidbody>().position);
			stream.SendNext(GetComponent<Rigidbody>().rotation);
			stream.SendNext(GetComponent<Rigidbody>().velocity);
			stream.SendNext(GetComponent<Rigidbody>().angularVelocity);
		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago, and update our version of that player.

			anim.SetFloat("Speed", (float)stream.ReceiveNext());
			anim.SetFloat("Rotation", (float)stream.ReceiveNext());
			anim.SetBool("Ground", (bool)stream.ReceiveNext());
			anim.SetFloat("vSpeed", (float)stream.ReceiveNext());
			anim.SetFloat("Strafe", (float)stream.ReceiveNext());
			anim.SetBool("Dead", (bool)stream.ReceiveNext());
			anim.SetBool("Throw", (bool)stream.ReceiveNext());
			anim.SetBool("Push", (bool)stream.ReceiveNext());

			realPosition2 = (Vector3)stream.ReceiveNext();
			realRotation2 = (Quaternion)stream.ReceiveNext();
			rigidbodyVel = (Vector3)stream.ReceiveNext();
			
			rigidbodyAngVel = (Vector3)stream.ReceiveNext();
			
			if(gotFirstUpdate == false) {

				GetComponent<Rigidbody>().position = realPosition2;
				GetComponent<Rigidbody>().rotation = realRotation2;
				GetComponent<Rigidbody>().velocity = rigidbodyVel;
				GetComponent<Rigidbody>().velocity = rigidbodyAngVel;
				gotFirstUpdate = true;
			}
		}

	}
}
