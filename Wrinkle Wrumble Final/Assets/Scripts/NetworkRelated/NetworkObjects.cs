using UnityEngine;
using System.Collections;

public class NetworkObjects : Photon.MonoBehaviour {
		
		Vector3 realScale = Vector3.one;

		Vector3 realPosition2 = Vector3.zero;
		Vector3 rigidbodyVel = Vector3.zero;
		Vector3 rigidbodyAngVel = Vector3.zero;
		Quaternion realRotation2 = Quaternion.identity;

		
		Animator anim;
		bool gotFirstUpdate = false;

		void FixedUpdate ()
		{
			if(!photonView.isMine)
			{
			transform.localScale = realScale;

			GetComponent<Rigidbody>().position = Vector3.Lerp(GetComponent<Rigidbody>().position, realPosition2, 0.1f);
				GetComponent<Rigidbody>().velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, rigidbodyVel, 0.1f);
				GetComponent<Rigidbody>().rotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, realRotation2, 0.1f);
				
				GetComponent<Rigidbody>().angularVelocity = Vector3.Lerp(GetComponent<Rigidbody>().angularVelocity, rigidbodyAngVel, 0.1f);

			}
		}
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
			if(stream.isWriting) {
				// This is OUR player. We need to send our actual position to the network.
				stream.SendNext(transform.localScale);

				stream.SendNext(GetComponent<Rigidbody>().position);
				stream.SendNext(GetComponent<Rigidbody>().rotation);
				stream.SendNext(GetComponent<Rigidbody>().velocity);
				stream.SendNext(GetComponent<Rigidbody>().angularVelocity);
		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
				// millisecond ago, and update our version of that player.
				
				realScale = (Vector3)stream.ReceiveNext();

				realPosition2 = (Vector3)stream.ReceiveNext();
				realRotation2 = (Quaternion)stream.ReceiveNext();
				rigidbodyVel = (Vector3)stream.ReceiveNext();
				
				rigidbodyAngVel = (Vector3)stream.ReceiveNext();

			if(gotFirstUpdate == false) {
				transform.localScale = realScale;
				GetComponent<Rigidbody>().position = realPosition2;
				GetComponent<Rigidbody>().rotation = realRotation2;
				GetComponent<Rigidbody>().velocity = rigidbodyVel;
				GetComponent<Rigidbody>().velocity = rigidbodyAngVel;
				gotFirstUpdate = true;
			}
		}
		
	}

	[RPC]
	public void killObject(){
		PhotonNetwork.Destroy (gameObject);
		Destroy (gameObject);
	}
}
