using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Ikatyros.LuckyNight
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        public static NetworkManager Instance { get; private set; }

        public string Status;
        public string Username;

        internal StartCanvas StartCanvas;
        private bool _willCreateRoom;

        public List<string> PlayersInRoom { get; private set; } = new List<string>();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Status = "Disconnected.";
        }

        public void JoinAsMaestro()
        {
            _willCreateRoom = true;
            Username = "[maestro {index}]";
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
                return;
            }
            PhotonNetwork.ConnectUsingSettings();
        }

        public void JoinAsAgent(string username)
        {
            Username = username;
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
                return;
            }
            PhotonNetwork.ConnectUsingSettings();
        }

        public void JoinAsSpectator()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
                return;
            }
            Username = "[spectator {index}]";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinRandomRoom();
            Status = "Connected to master.";
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinedRoom()
        {
            Status = $"Joined a room as {Username}!";
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Status = "No random room available.";
            // if tried to join a game as maestro and there were no rooms available,
            // create a new room for the maestro.
            if (_willCreateRoom)
            {
                CreateRoom();
            }
            else
            {
                StartCanvas.ReturnToInput();
            }
        }

        public void CreateRoom()
        {
            var opt = new RoomOptions() { IsVisible = true, MaxPlayers = 20 };
            PhotonNetwork.JoinOrCreateRoom("game1", opt, TypedLobby.Default);
            Status = "Created a random room.";
        }
    }
}