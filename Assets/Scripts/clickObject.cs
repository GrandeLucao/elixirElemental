using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickObject : MonoBehaviour
{
    public GameObject frasco1,frasco2,frasco3,frasco4;
    public Elements El1,El2,El3,El4;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                if(frasco1==getClickedObject(out  hit)){
                    El1.selected();
                }
                if(frasco2==getClickedObject(out  hit)){
                    El2.selected();
                }
                if(frasco3==getClickedObject(out  hit)){
                    El3.selected();
                }
                if(frasco4==getClickedObject(out  hit)){
                    El4.selected();
                }
            }
        
    }



    GameObject getClickedObject(out RaycastHit hit){
        GameObject target=null;
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin, ray.direction*10, out hit)){
            if(!isPointerOverUIObject()){target=hit.collider.gameObject;}
        }
        return target;
    }
    private bool isPointerOverUIObject(){
        PointerEventData ped=new PointerEventData(EventSystem.current);
        ped.position=new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        List<RaycastResult> results=new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped,results);
        return results.Count>0;
    }
}
