using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private static int? winCount;
    private static int? loseCount;

    public int WinCount { get => winCount.Value; set => winCount = value; }
    public int LoseCount { get => loseCount.Value; set => loseCount = value; }
    void Start()
    {
        winCount ??= 0;
        loseCount ??= 0;
    }
}
