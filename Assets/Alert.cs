using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    public Text alertText;
    public float timeToShow = 2f;

    public void setText(string text)
    {
        alertText.text = text;
        CancelInvoke();
        Invoke("ClearText", timeToShow);
    }

    private void ClearText()
    {
        alertText.text = "";
    }
}
