using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private Transform sidePos;
    [SerializeField] private Transform button;

    public void ClickChat()
    {
        chatPanel.SetActive(!chatPanel.activeSelf);
        button.position = sidePos.position;
    }
}
