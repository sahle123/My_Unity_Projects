using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	private const string typeName = "UniqueGameName";
	private const string gameName = "Sal's Room";
	private HostData[] hostList;
	
	// *** Search *** //
	// Search for a server
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	// Once we find a server, this function will run.
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if(msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
	
	// *** Join *** //
	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}
	
	// This function automatically runs when the program connects to a server.
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}
	
	// *** Host *** //
	void StartServer()
	{
		MasterServer.ipAddress = "127.0.0.1";
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	// This runs automatically after Network.InitializeServer()
	void OnServerInitialized()
	{
		Debug.Log("Server Initialized");
	}
	
	void OnGUI()
	{
		// Starting server if we have no client or server
		if ((!Network.isClient) && (!Network.isServer))
		{
			if (GUI.Button(new Rect (100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect (100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for(int i = 0; i < hostList.Length; ++i)
				{
					if(GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
}