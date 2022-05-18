using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spawn_mainchar : MonoBehaviour
{
    public string SceneName;
    public Vector3 playerPos;
    public GameObject prefab_mainchar,prefab_camera,prefab_canvas;
    Camera_Controller camera_Controller;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

        GameObject canvas = Instantiate(prefab_canvas);
        GameObject jugador = Instantiate(prefab_mainchar);
        GameObject camera = Instantiate(prefab_camera);
        jugador.GetComponent<MainCharPueblo_Movement>().SetDialogueUI(canvas.GetComponent<DialogueUI>());
        playerPos.z = -21;
        jugador.transform.position = playerPos;
        playerPos.z = -50;
        camera.transform.position = playerPos;
        camera_Controller = camera.GetComponent<Camera_Controller>();
        camera_Controller.player = jugador.transform;
    }


}
