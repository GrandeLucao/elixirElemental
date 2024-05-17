using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    [SerializeField]
    private string name, value;
    private Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selected(){
        Debug.Log(name+", "+value);
        //play animation
        //save this object code to array
        //disable clicking other itens
        //display name on screen

        //on animation end
        //re-enable clicking
    }

    public void selectedObjects(string value){
        //Get array
        //add value to array 
        //if 3 positions are filled
            //send this array to outside function to mixture a result
            //disable clicking
    }

    public void deselectObjects(string value){
        //get array
        //compare to find exact value
        //remove from array
    }
}
