using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;   
    private void Start()
    {
        foreach(GameObject gameObject in DontDestroyOnLoadManager._ddolObjects)
        {
            if(gameObject.tag == "Player")
            {
                player = gameObject.transform;               
            }
        }
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
