using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-100)]
public class BootStrap : MonoBehaviour
{
    [SerializeField] private List<StringVariable> scenesToLoad;
    [SerializeField] private bool bInBoostrap;
    private void Awake()
    {

        foreach (var scene in scenesToLoad)
        {
            if (!SceneManager.GetSceneByName(scene.Value).isLoaded)
                SceneManager.LoadScene(scene.Value, LoadSceneMode.Additive);
        }

    }

    private void Start()
    {
        Destroy(gameObject);
        if (bInBoostrap == true)
            SceneManager.UnloadSceneAsync("BootStrap");
    }
}
