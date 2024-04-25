using Inworld;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    [SerializeField] TMP_InputField m_InputField;
    public void SendText()
    {
        if (!m_InputField || string.IsNullOrEmpty(m_InputField.text) || !InworldController.CurrentCharacter)
            return;
        try
        {
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
