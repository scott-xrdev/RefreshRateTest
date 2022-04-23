using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI debugText;

    public void LogText(string message)
    {
        if (debugText)
        {
            debugText.text += "\n" + message;
        }

        Debug.Log(message);
    }
}
