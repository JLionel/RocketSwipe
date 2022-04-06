using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //called with a GameEvent
    public void Unload(StringVariable scene)
    {
        if (SceneManager.GetSceneByName(scene.Value).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene.Value);
        }
    }
    
    //called with a GameEvent
    public void Load(StringVariable scene)
    {
        if (!SceneManager.GetSceneByName(scene.Value).isLoaded)
        {
            SceneManager.LoadScene(scene.Value, LoadSceneMode.Additive);
        }
    }
    
    //called with a GameEvent
    public void ReLoad(StringVariable scene)
    {
        Unload(scene);
        Load(scene);
    }
}
