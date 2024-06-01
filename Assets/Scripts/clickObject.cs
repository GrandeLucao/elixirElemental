using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickObject : MonoBehaviour
{
    public MixData mixDT;
    public int[] mixtureElem=new int[]{2,0,0};
    public GameObject frasco1,frasco2,frasco3,frasco4;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                if(frasco1==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote1");
                    mixtureElem[0]=2;
                    mixtureElem[1]=3;
                    mixDT.cookMix(mixtureElem);
                }
                if(frasco2==getClickedObject(out  hit)){
                    Debug.Log(mixtureElem[1].ToString());
                    
                }
                if(frasco3==getClickedObject(out  hit)){
                    
                }
                if(frasco4==getClickedObject(out  hit)){
                    
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
