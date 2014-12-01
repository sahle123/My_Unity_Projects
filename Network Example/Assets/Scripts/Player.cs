using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;

	private float lastSyncTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void Update()
	{
		// Only the player that owns the object can manipulate it
		if(networkView.isMine)
		{
			InputMovement();
			InputColorChange();
		}
		else
		{
			SyncedMovement();
		}
	}

	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
	}
	// Interpolate the change in position.
	private void SyncedMovement()
	{
		syncTime = syncTime + Time.deltaTime;
		rigidbody.position = Vector3.Lerp (syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	// For state synchronization. This is used in conjunction with the
	// Network View component.
	// This will gve us control on synchronization.
	void OnSerializeNetworkView(BitStream leStream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero; // For prediction

		if(leStream.isWriting)
		{
			syncPosition = rigidbody.position;
			leStream.Serialize (ref syncPosition);

			// For prediction
			syncVelocity = rigidbody.velocity;
			leStream.Serialize (ref syncVelocity);
		}
		else
		{
			leStream.Serialize (ref syncPosition);
			leStream.Serialize (ref syncVelocity); // For prediction

			syncTime = 0f;
			syncDelay = Time.time - lastSyncTime;
			lastSyncTime = Time.time;

			syncEndPosition = syncPosition + syncVelocity; 
			syncStartPosition = rigidbody.position;
		}
	}

	private void InputColorChange()
	{
		if(Input.GetKeyDown (KeyCode.R))
			ChangeColorTo(new Vector3(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f)));
	}

	[RPC] void ChangeColorTo(Vector3 color)
	{
		renderer.material.color = new Color (color.x, color.y, color.z, 1f);

		if(networkView.isMine)
			networkView.RPC ("ChangeColorTo", RPCMode.OthersBuffered, color);
	}
}