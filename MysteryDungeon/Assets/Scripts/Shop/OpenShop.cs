using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public bool IsOpen { get; private set; }

    private void Awake()
    {     
        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void OnPickedResponse(Camera camera)
    {     
        this.gameObject.transform.position = new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y,-22);
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        IsOpen = this.gameObject.activeSelf;
    }

    public void CloseShop()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        IsOpen = this.gameObject.activeSelf;
    }
        
}
