using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmusic : MonoBehaviour
{
    [SerializeField] private string musicName;
    [SerializeField] private bool stop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (stop)
        {
            FindObjectOfType<AudioManager>().StopAll();
        }
        FindObjectOfType<AudioManager>().Play(musicName);
    }

    public void PlayMusic()
    {      
        if (stop)
        {
            FindObjectOfType<AudioManager>().StopAll();
        }
        FindObjectOfType<AudioManager>().Play(musicName);       
    }
}
