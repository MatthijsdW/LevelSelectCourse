using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            levelController.CompleteLevel("Getting Goin'", 2);
            levelController.UnlockLevel("Yee-haw");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelController.StartLevel("LevelSelect");
        }
    }
}
