using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music, blade;
    public AudioClip[] bladeAudio, fruitSplashAudio;
    public AudioClip bombExplodeAudio;
    [SerializeField] private AudioSource[] audioSources;
    private GameController gameController;
    [SerializeField] private float musicVolume, soundsVolume;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        EnableAndDisableAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAndDisableAudio()
    {
        if(gameController.soundOnOff)
        {
            audioSources[0].volume = musicVolume;

            for(int i = 1; i < audioSources.Length; i++)
            {
                audioSources[i].volume =  soundsVolume;
            }
        }
        else
        {
            for(int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume =  0f;
            }

            foreach(Transform child in gameController.allObjects)
            {
                child.gameObject.GetComponent<AudioSource>().volume = 0f;
            }
        }
    }
}
