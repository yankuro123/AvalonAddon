using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Text;
using System;

public class PlayerTypeSelection : NetworkBehaviour
{
    public Button Host;
    public Button Player;
    public Button Login;
    public string host;
    public string player;
    [SerializeField]
    public static NetworkVariable<int> ID = new NetworkVariable<int>(0);
    [SerializeField]
    public static NetworkVariable<int> Counter = new NetworkVariable<int>(0);
    [SerializeField]public InputField IDtaker;

    public static bool hosted = false;
    // Start is called before the first frame update
    void Start()
    {
        CanvasHandling.handler = 0;
        IDtaker.GetComponent<InputField>();
        //IDtaker.GetComponent<InputField>().enabled = false;
        Host.GetComponent<Button>();
        Player.GetComponent<Button>();
        Login.GetComponent<Button>();
        Host.onClick.AddListener(HostSelected);
        Player.onClick.AddListener(PlayerSelected);
        Login.onClick.AddListener(LoginConfirm);
        Login.gameObject.SetActive(false);
        IDtaker.gameObject.SetActive(false);
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += ConnectedHandle;
        NetworkManager.Singleton.OnClientDisconnectCallback += DisconnectedHandle;
    }
    private void Destroy()
    {
        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= ConnectedHandle;
        NetworkManager.Singleton.OnClientDisconnectCallback -= DisconnectedHandle;
    }
        // Update is called once per frame
        void Update()
    {

    }
    void HostSelected()
    {
        ID = new NetworkVariable<int>(UnityEngine.Random.Range(0001, 9999));
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
       //NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(ID.Value.ToString());
        NetworkManager.Singleton.StartHost();
        Debug.Log("PUT-IN: " + ID.Value.ToString());
        Debug.Log("put-in client: " + IDtaker.text);
    }
    void PlayerSelected()
    {
        Login.gameObject.SetActive(true);
        IDtaker.gameObject.SetActive(true);       
    }
    void LoginConfirm()
    {
        NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(IDtaker.text);
        var test = Encoding.ASCII.GetBytes(IDtaker.text);
        NetworkManager.Singleton.StartClient();
        Debug.Log("put-in client: " + IDtaker.text);
    }
    public void ApprovalCheck(byte[] ConnectionData, ulong ClientID, NetworkManager.ConnectionApprovedDelegate Callback)
    {
        //string Code = ID.Value.ToString();
        ConnectionData = Encoding.ASCII.GetBytes(ID.Value.ToString());
        string IDCode = Encoding.ASCII.GetString(ConnectionData);
        bool approveconnection = IDCode == IDtaker.text;
        Callback(false, null, approveconnection, null, null);
        Debug.Log("IDCODE: " + IDCode);
    }
    private void HandleServerStarted()
    {
        Debug.Log("Server Started");
        Debug.Log(ID.Value);
    }
    private void ConnectedHandle(ulong ClientID)
    {
        if (ClientID == NetworkManager.Singleton.LocalClientId)
        {
            if (NetworkManager.Singleton.IsHost == true)
            {
                Counter.Value += 0;
                CanvasHandling.handler = 1;
            }
            else if (NetworkManager.Singleton.IsClient == true)
            {
                Counter.Value += 1;
                CanvasHandling.handler = 2;
            }

        }
        Debug.Log("Player Connected");

    }
    private void DisconnectedHandle(ulong ClientID)
    {
        if (NetworkManager.Singleton.IsHost == true)
        {
            if (NetworkManager.Singleton.IsHost == true)
            {
                PlayerSelectManager.picker = new NetworkVariable<int>(0);
                CanvasHandling.handler = 0;
            }
            else if (NetworkManager.Singleton.IsClient == true)
            {
                Counter.Value -= 1;
                CanvasHandling.handler = 0;
            }
        }   
        Debug.Log("Player Disconnected");
    }

}