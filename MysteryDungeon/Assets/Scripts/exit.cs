using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    [SerializeField]
    private DungeonGenerator dg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.transform.position = new Vector3 ((float) 0.5,(float) 0.5, collision.transform.position.z);
            dg.load();
        }

    }
}
