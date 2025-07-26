using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //ref GameManager
    private GameManager gm;
    //ref to rigibody
    

    //bool
    //private bool combine = false;
    //index of fruit
    public int fruitIndex;
    // Start is called before the first frame update
    void Start()
    {
        //Get GameManager
        gm = GetComponent<GameManager>();
        //get Rigibody
        
    }
    public void GravityOn()
    {
        Debug.Log("Turning Gravity On");
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }
}
