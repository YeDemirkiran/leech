using System;
using UnityEngine;
using TMPro;

public class DisplayUsername : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    string username;

    void Start()
    {
        username = Environment.UserName;
        tmpText.text = username;
    }
}
