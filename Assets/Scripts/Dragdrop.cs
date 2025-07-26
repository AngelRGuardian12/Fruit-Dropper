using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragdrop : MonoBehaviour
{
    //ref to cam
    private GameManager gm;
    private Camera cam;

    private Fruit fruit;
    private Vector3 dragoffset;

    public bool dragBool;

    public float followSpeed;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
        fruit = GetComponent<Fruit>();
    }
    //mouse up
    private void OnMouseUp()
    {
        //drop the object
        Debug.Log("pressed");
        drop();
    }
    //mouse down
    private void OnMouseDown()
    {
        dragoffset = transform.position - getMousePosition();
    }
    //mouse drag
    private void OnMouseDrag()
    {
        if (dragBool)
        {
            Debug.Log("Draggable true");
            //transform.position = getMousePosition();
            //transform.position = getMousePosition() + dragoffset;
            transform.position = Vector3.MoveTowards(transform.position, getMousePosition() + dragoffset, followSpeed * Time.deltaTime);
        }
        
    }
    //get mouse position
    private Vector3 getMousePosition()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
    //function drop
    public void drop()
    {
        Debug.Log("Dropping");
        if (dragBool)
        {
            dragBool = false;
            fruit.GravityOn();
            gm.SpawnNewFruit();
        }
    }
    //collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Box") && dragBool == true)
        {
            drop();
        }
    }
}
