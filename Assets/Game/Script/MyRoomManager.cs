using Inworld;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyRoomManager : MonoBehaviour
{
    [SerializeField] TMP_InputField m_InputField;
    public void SendText()
    {
        Debug.Log("send text");
        if (!InworldController.CurrentCharacter)
        {
            Debug.Log("no character");
        }
        if (!m_InputField || string.IsNullOrEmpty(m_InputField.text) || !InworldController.CurrentCharacter)
            return;
        try
        {
            Debug.Log("abc");
            if (InworldController.CurrentCharacter)
                InworldController.CurrentCharacter.SendText(m_InputField.text);
            m_InputField.text = "";
        }
        catch (InworldException e)
        {
            InworldAI.LogWarning($"Failed to send texts: {e}");
        }
    }
}
