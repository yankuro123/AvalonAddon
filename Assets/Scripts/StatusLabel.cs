using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class StatusLabel : MonoBehaviour
{
    public Text status;
    public Text Counter;
    public Text ID;
    public Button Leave;
    //public static int PlayerCount;
    // Start is called before the first frame update
    void Start()
    {
        status.GetComponent<Text>();
        Counter.GetComponent<Text>();
        ulong localClientId = NetworkManager.Singleton.LocalClientId;
    }
    private void Update()
    {
        string mode = StatusLabels();
        ID.text = "RoomID: " + PlayerTypeSelection.ID.Value; 
        ID.color = Color.red;
        status.text = "Joining as: " + mode;
        status.color = Color.green;
        Counter.text = PlayerTypeSelection.Counter.Value + "/" + PlayerSelectManager.picker.Value + " Connected";
        Counter.color = Color.white;
        /*if (PlayerCount == PlayerSelectManager.picker)
        {
            (move to game screen)
        }*/
    }
    // Update is called once per frame
    static string StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : "Client";
        return mode;
    }
}
