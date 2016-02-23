using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiMangler : MonoBehaviour {

	public NetMangler netMangler;
	public Text serverStatus;
	public Text hosts;
	public GameObject initButton;
	public GameObject serverButton;
	public GameObject listenButton;
	public GameObject hostButton;
	public GameObject joinButton;
	public string hostIP;
	public string hostsString = "";

	public Text joinButtonLabel;
	// Use this for initialization
	void Start () {
		serverButton.SetActive (false);
		listenButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeButton() {
		netMangler.Init ();
		initButton.SetActive (false);
		serverButton.SetActive (true);
		listenButton.SetActive (true);
		serverStatus.text = netMangler.discovery.broadcastData;
	}

	public void ServerButton() {
		netMangler.StartDiscoveryServer ();
		serverButton.SetActive (false);
		listenButton.SetActive (false);
		hostButton.SetActive (true);
//		joinButton.SetActive (true);
		serverStatus.text = "Broadcasting from " + netMangler.networkAddress;
	}

	public void ListenButton () {
		netMangler.StartDiscoveryClient ();
		serverButton.SetActive (false);
		listenButton.SetActive (false);
		joinButton.SetActive (true);
		serverStatus.text = "Broadcast Listener Started";
	}
	public void IncomingHosts(string hostData) {
//		if (!netMangler.IsClientConnected()) {
//			hosts.text = hostData; 
//			ShowJoinButton ();
//		} else {
//			HideJoinButton ();
//			netMangler.discovery.StopBroadcast ();
//		}
		hosts.text = "host found at " + hostData; 
		joinButtonLabel.text = hostData;
	}

	public void LanHostButton() {
		netMangler.StartGameHost ();
	
	}
	public void HideHostButton() {
		hostButton.SetActive (false);
	}
	public void ShowJoinButton() {
		joinButton.SetActive (true);
	}
	public void HideJoinButton() {
		joinButton.SetActive (false);
	}

	public void LanClientButton() {
		netMangler.StartGameClient ();
	}
}
