using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusica : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("TemaPrincipal");
    }
}
