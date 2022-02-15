using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System.Text;

public class PlayerSelectManager : MonoBehaviour
{
    [SerializeField]
    public static NetworkVariable<int> picker;
    public Button pick5;
    public Button pick6;
    public Button pick7;
    public Button pick8;
    public Button pick9;
    public Button pick10;
    // Start is called before the first frame update
    void Start()
    {
        pick5.GetComponent<Button>();
        pick6.GetComponent<Button>();
        pick7.GetComponent<Button>();
        pick8.GetComponent<Button>();
        pick9.GetComponent<Button>();
        pick10.GetComponent<Button>();
        pick5.onClick.AddListener(setup5);
        pick6.onClick.AddListener(setup6);
        pick7.onClick.AddListener(setup7);
        pick8.onClick.AddListener(setup8);
        pick9.onClick.AddListener(setup9);
        pick10.onClick.AddListener(setup10);
    }
    private void Destroy()
    {

    }
    public void setup5()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(5);
    }
    public void setup6()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(6);
    }
    public void setup7()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(7);
    }
    public void setup8()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(8);
    }
    public void setup9()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(9);
    }
    public void setup10()
    {
        CanvasHandling.handler = 2;
        picker = new NetworkVariable<int>(10);
    }
    
}

