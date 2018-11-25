using System;
using UnityEngine;
using BestHTTP;
using BestHTTP.SocketIO;

public class SocketIOExample : MonoBehaviour {

  SocketManager socketManager;
  public string socketServerAddress = "localhost";
  public int port = 3000;

  // Use this for initialization
  void Start () {
    string socketAddr = "http://" + socketServerAddress + ":" + port.ToString() + "/socket.io/:8443";
    Debug.Log("Connecting to: " + socketAddr);
    InitSocketManager(socketAddr);
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  void InitSocketManager(string uri) {
    socketManager = new SocketManager(new Uri(uri));
    socketManager.Socket.AutoDecodePayload = false;
    socketManager.Socket.On("error", SocketError);
    socketManager.Socket.On("connect", SocketConnected);
    socketManager.Socket.On("reconnect", SocketConnected);
    socketManager.Socket.On("mySocketEvent", ReceivedMySocketEvent);
  }

  void SocketConnected(Socket socket, Packet packet, params object[] args) {
    Debug.Log(DateTime.Now + " - " + "Success connecting to sockets");
  }

  void SocketError(Socket socket, Packet packet, params object[] args) {
    Debug.LogError(DateTime.Now + " - " + "Error connecting to sockets");

    // Do something in error event

    if (args.Length > 0) {
      Error error = args[0] as Error;
      if (error != null) {
        switch (error.Code) {
          case SocketIOErrors.User:
            Debug.LogError("Exception in an event handler!");
            break;
          case SocketIOErrors.Internal:
            Debug.LogError("Internal error!");
            break;
          default:
            Debug.LogError("Server error!");
            break;
        }
        Debug.LogError(error.ToString());
        return;
      }
    }
    Debug.LogError("Could not Parse Error!");
  }

  void ReceivedMySocketEvent(Socket socket, Packet packet, params object[] args) {
    string eventName = packet.DecodeEventName();
    string eventPayload = packet.RemoveEventName(true);
    Debug.Log(eventName);
    Debug.Log(eventPayload);
  }

  public void SendSomeData(string dataString) {
    socketManager.Socket.Emit("myOutgoingData", dataString);
  }

  void OnApplicationQuit() {
    socketManager.Close();
  }
}
