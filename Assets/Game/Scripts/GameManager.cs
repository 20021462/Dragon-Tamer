using Inworld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private UIController UIController;

    private bool welcomeBack = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //LoadScene("MyRoom");
        SceneManager.LoadSceneAsync("MyRoom", LoadSceneMode.Single);
    }

    private void Update()
    {
        if (!welcomeBack)
        {
            if (InworldController.Client.Status == InworldConnectionStatus.Connected) 
            {
                InworldController.CurrentCharacter.SendTrigger("welcome_back");
                welcomeBack = true;
            }
        }
    }

    public void LoadAdventure()
    {
        StartCoroutine(LoadScene("Adventure", () =>
        {
            UIController.ChangeButton(false);
            InworldController.CurrentCharacter.SendTrigger("adventure_ready");
        }));

    }

    public void LoadMyRoom()
    {
        StartCoroutine(LoadScene("MyRoom", () =>
        {
            UIController.ChangeButton(true);
        }));
    }

    public IEnumerator LoadScene(string sceneName, Action onComplete = null)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        yield return operation;
        onComplete?.Invoke();
    }

    public void SendTrigger(string trigger, Dictionary<string, string> parameters = null)
    {
        if (InworldController.Client.Status == InworldConnectionStatus.Connected)
        {
            int random = UnityEngine.Random.Range(0, 15);
            if (random == 8)
            {
                InworldController.CurrentCharacter.SendTrigger(trigger, false, parameters);
            }
        }
    }
}
