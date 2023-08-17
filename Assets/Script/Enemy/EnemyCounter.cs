using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public List<GameObject> enemies = new();
    private SceneController sceneController;
    private Storage storage;

    void Start()
    {
        sceneController = GetComponent<SceneController>();
        storage = GetComponent<Storage>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies.RemoveAll(a => a == null);
        if (enemies.Count == 0)
        {
            storage.WinCount++;
            sceneController.LoadLevel("Game end");
        }
    }
}
