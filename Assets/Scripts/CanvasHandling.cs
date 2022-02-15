using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasHandling : MonoBehaviour
{
    public Canvas Titlescreen;
    public Canvas HostScreen;
    public Canvas RoomScreen;

    public static int handler;
    // Start is called before the first frame update
    void Start()
    {
        Titlescreen.GetComponent<Canvas>();
        HostScreen.GetComponent<Canvas>();
        RoomScreen.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        int test = handler;
        if(handler == 0)
        {
            RoomScreen.GetComponent<StatusLabel>().enabled = false;
            Titlescreen.gameObject.SetActive(true);
            HostScreen.gameObject.SetActive( false);
            RoomScreen.gameObject.SetActive(false);
        }
        else if(handler == 1)
        {
            RoomScreen.GetComponent<StatusLabel>().enabled = false;
            Titlescreen.GetComponent<PlayerTypeSelection>().enabled = true;
            Titlescreen.gameObject.SetActive(false);
            HostScreen.gameObject.SetActive(true);
            RoomScreen.gameObject.SetActive(false);
        }
        else if(handler == 2)
        {
            RoomScreen.GetComponent<StatusLabel>().enabled = true;
            Titlescreen.gameObject.SetActive(false);
            HostScreen.gameObject.SetActive(false);
            RoomScreen.gameObject.SetActive(true);
        }
    }
}
