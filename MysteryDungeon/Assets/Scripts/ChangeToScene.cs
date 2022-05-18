using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToScene : MonoBehaviour
{
    public String SceneName;
    public Vector3 spawnpos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DontDestroyOnLoadManager.DontDestroyOnLoad(collision.gameObject);
            collision.gameObject.transform.position = new Vector3(0, collision.gameObject.transform.position.y - 1, -21);
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
