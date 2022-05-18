using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainchar_Movement : Player
{
    // Start is called before the first frame update
    int Zpos = -8;
    public SpriteRenderer spriteRenderer;
    public Collider2D Collider2D;
    public LayerMask[] wallMask;
    public LayerMask enemyMask;
    private BoxCollider2D bloquearriba, bloquederecha, bloqueabajo, bloqueizquierda;
    [SerializeField]
    private Sprite spriteArriba;
    [SerializeField]
    private Sprite spriteAbajo;
    [SerializeField]
    private Sprite spriteLateral;
    
    public bool turno, block = false;
    // Start is called before the first frame update
    void Start()
    {
        turno = true;
        bloquearriba = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
        bloquederecha = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
        bloqueabajo = this.transform.GetChild(2).GetComponent<BoxCollider2D>();
        bloqueizquierda = this.transform.GetChild(3).GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == enemyMask) 
        try{ 
            collision.gameObject.GetComponent<Enemy_Movement>().isInRange = true;    
        }catch (NullReferenceException) { }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == enemyMask)
        try { 
            collision.gameObject.GetComponent<Enemy_Movement>().isInRange = false;
        }
        catch (NullReferenceException) { }
    }
    
    void Update()
    {
        if (!block) { 
        if (moveValidate(bloqueizquierda))
        {
            if (Input.GetKeyDown(KeyCode.A) && turno)
            {
                turnChange();
                StartCoroutine(moveXonA());
            }
        }
        if (moveValidate(bloquederecha))
        {
            if (Input.GetKeyDown(KeyCode.D) && turno)
            {
                turnChange();
                StartCoroutine(moveXonD());
            }
        }
        if (moveValidate(bloquearriba))
        {
            if (Input.GetKeyDown(KeyCode.W) && turno)
            {
                turnChange();
                StartCoroutine(moveXonW());
            }
        }
        if (moveValidate(bloqueabajo))
        {
            if (Input.GetKeyDown(KeyCode.S) && turno)
            {
                turnChange();
                StartCoroutine(moveXonS());
            }
        }
        }
    }

    public void turnChange()
    {
        turno = !turno;
    }

    IEnumerator moveXonA()
    {
        spriteRenderer.flipX = false;
        spriteRenderer.sprite = spriteLateral;
        for (int x = 0; x < 40; x++)
        {
            this.transform.position = new Vector3((float)(this.transform.position.x - 0.025), this.transform.position.y,Zpos);
            yield return new WaitForSecondsRealtime((float)0.0002);
        }       
    }

    IEnumerator moveXonD()
    {

        spriteRenderer.flipX = true;
        spriteRenderer.sprite = spriteLateral;
        for (int x = 0; x < 40; x++)
        {
            this.transform.position = new Vector3((float)(this.transform.position.x + 0.025), this.transform.position.y, Zpos);
            yield return new WaitForSecondsRealtime((float)0.0002);
        }
    }

    IEnumerator moveXonW()
    {
        spriteRenderer.sprite = spriteArriba;
        for (int x = 0; x < 40; x++)
        {
            this.transform.position = new Vector3(this.transform.position.x, (float)(this.transform.position.y + 0.025), Zpos);
            yield return new WaitForSecondsRealtime((float)0.0002);
        }
    }

    IEnumerator moveXonS()
    {
        spriteRenderer.sprite = spriteAbajo;
        for (int x = 0; x < 40; x++)
        {
            this.transform.position = new Vector3(this.transform.position.x, (float)(this.transform.position.y - 0.025), Zpos);
            yield return new WaitForSecondsRealtime((float)0.0002);
        }
        
    }

    private bool moveValidate(BoxCollider2D collider)
    {
        foreach(LayerMask layerMask in wallMask)
        {
            if (collider.IsTouchingLayers(layerMask))
            {
                return false;
            }
        }
        return true;
    }
}
