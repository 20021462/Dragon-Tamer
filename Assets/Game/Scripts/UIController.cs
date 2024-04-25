using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private GameObject button;

    public void ClickChat()
    {
        Debug.Log("abc");
        chatPanel.SetActive(!chatPanel.activeSelf);
        button.SetActive(!button.activeSelf);
    }
}
