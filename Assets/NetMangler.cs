using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using UnityEngine.Networking;

public class NetMangler : NetworkManager
{
	public GuiMangler guiMangler;
	public NetworkDiscovery discovery;
	public string serverdata;
	NetworkClient myClient;
	public string hostIP;

	public Dictionary<string,UnityEngine.Networking.NetworkBroadcastResult> broadcasts;

//	public override void OnStartHost()
//	{
//		discovery.Initialize();
//		discovery.StartAsServer();
//
//	}


	public void StartDiscoveryServer() {
		discovery.StartAsServer ();
	}

	public void StartDiscoveryClient() {
		discovery.StartAsClient ();
	}

	public void StartGameHost() {
		StartHost ();
	}
	public void StartGameClient() {
			
		networkAddress = hostIP;
		StartClient ();

//			myClient = new NetworkClient();
//			myClient.RegisterHandler(MsgType.Connect, OnConnected);     
//			myClient.Connect(hostIP, 7777);
	}
//	public void OnConnected(NetworkMessage netMsg)
//	{
//		Debug.Log("Connected to server");
//		guiMangler.IncomingHosts ("joined game at " + hostIP);
//
//	}
	public void Init() {
		discovery.Initialize ();
		serverdata = discovery.broadcastData;
		InvokeRepeating ("BroadcastCheck", 1f, 1f);
	}
	public override void OnStartHost() {
		guiMangler.HideHostButton ();
		guiMangler.HideJoinButton ();
	}
	public override void OnStartClient(NetworkClient client)
	{
		discovery.showGUI = false;
		guiMangler.HideJoinButton ();
		guiMangler.hosts.text = "joined host at " + networkAddress;
		CancelInvoke ();
	}


	public override void OnStopClient()
	{
		discovery.StopBroadcast();
		discovery.showGUI = true;
	}

	public void BroadcastCheck () {
		
		broadcasts = discovery.broadcastsReceived;
		if (broadcasts != null) {
			foreach (var pair in broadcasts) {
				var key = pair.Key;
				var value = pair.Value;

				hostIP = key; //TODO chooser
//				guiMangler.HideHostButton();
//				guiMangler.ShowJoinButton ();
			}
		}
	}
//	public Update () {
//		discovery.broadcastsReceived
//	{
//		guiMangler.IncomingHosts (data + " : " + fromAddress);
//	}
//	}
}
