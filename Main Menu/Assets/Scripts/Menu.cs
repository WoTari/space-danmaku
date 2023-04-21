using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public Button Play, Manual, Options, Quit, ExitManual;
    [SerializeField] private GameObject[] buttons;

    public GameObject ManualMenu;
    public GameObject List;


    void Start()
    {
        Play.onClick.AddListener(PlayGame);
        Manual.onClick.AddListener(OpenManual);
        Options.onClick.AddListener(Configs);
        Quit.onClick.AddListener(RageQuit);
        ExitManual.onClick.AddListener(CloseManual);
        
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
   
    void OpenManual()
    {
        List.SetActive(false);
        ManualMenu.SetActive(true);
    }

    void CloseManual()
    {
        List.SetActive(true);
        ManualMenu.SetActive(false);
    }

    void Configs()
    {
        Debug.Log("Config");
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }

    void RageQuit()
    {
        Debug.Log("Alt F4");
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            
        }
    }
}
