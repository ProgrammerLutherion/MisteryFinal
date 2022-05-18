using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField]
    private DungeonGenerator dungeonGenerator;
    [SerializeField]
    public Mainchar_Movement mainchar_movement;
    [SerializeField]
    private float cooldown;

    private void Start()
    {
        mainchar_movement = dungeonGenerator.player.GetComponent<Mainchar_Movement>();
    }

    void FixedUpdate()
    {
        if (!mainchar_movement.turno) 
        {
            StartCoroutine(timeout());
            dungeonGenerator.enemies.RemoveAll(s => s == null);
            foreach (var enemy in dungeonGenerator.enemies)
            {              
               enemy.GetComponent<Enemy_Movement>().Act();           
            }
            mainchar_movement.turnChange();
        }
    }

    IEnumerator timeout()
    {
        yield return new WaitForSecondsRealtime(cooldown);
    }
}
