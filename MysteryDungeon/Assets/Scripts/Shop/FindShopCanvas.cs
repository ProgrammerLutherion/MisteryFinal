using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindShopCanvas : MonoBehaviour
{
    public static OpenShop shopCanvas;
    
    private void Start()
    {
        foreach (GameObject gameObject in DontDestroyOnLoadManager._ddolObjects)
        {
            if (gameObject.tag == "ShopCanvas")
            {
                shopCanvas = gameObject.GetComponent<OpenShop>();
            }
        }
    }

    public void callOnPicked(Camera camera)
    {
        shopCanvas.GetComponent<OpenShop>().OnPickedResponse(camera);
    }
}
