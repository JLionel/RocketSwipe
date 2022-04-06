using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManageGlobalSounds : MonoBehaviour
{
    [SerializeField] private List<AudioSource> globalMusics;

    private AudioSource _currentAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(globalMusics?.Count > 0)
        {
            _currentAudioSource = globalMusics.First();
            _currentAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentAudioSource.isPlaying == false)
        {
            SwitchMusic();
        }
    }

    private void SwitchMusic()
    {
        _currentAudioSource.Stop();
        if (globalMusics.Count > 1)
        {
            globalMusics.Remove(_currentAudioSource);
            globalMusics.Add(_currentAudioSource);
            _currentAudioSource = globalMusics.First();
        }
        _currentAudioSource.Play();
    }
}
