using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace AssemblyWoodenBed
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public PlayerController Prefab;

        [HideInInspector]
        public PlayerController LocalPlayer;

        private void Awake()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LoadLevel(0);
                return;
            }
        }
        private void Start()
        {
            PlayerController.RefreshInstance(ref LocalPlayer, Prefab);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
    
            PlayerController.RefreshInstance(ref LocalPlayer, Prefab);
        }

    }
}
