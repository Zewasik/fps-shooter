using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI message;
    private Storage storage;

    // Start is called before the first frame update
    void Start()
    {
        storage = GetComponent<Storage>();
    }

    // Update is called once per frame
    void Update()
    {
        message.text = "Win count: " + storage.WinCount + "\n" + "Lose count: " + storage.LoseCount;
    }
}
