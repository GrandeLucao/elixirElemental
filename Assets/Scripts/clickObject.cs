using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickObject : MonoBehaviour
{
    public MixData mixDT;
    public int[] mixtureElem=new int[]{0,0,0};
    public GameObject frasco1,frasco2,frasco3,frasco4;
    public GameObject buttonMix;
    public int cont=0;

    void Update()
    {
            if(Input.GetMouseButtonDown(0) && cont<3){
                RaycastHit hit;
                if(frasco1==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote1");
                    canCook(1);
                }
                if(frasco2==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote2");
                    canCook(2);
                    
                }
                if(frasco3==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote3");
                    canCook(3);
                    
                }
                if(frasco4==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote4");
                    canCook(4);
                    
                }
            }
        
    }

    public void canCook(int IDEl)
    {
        bool found=false;
        for(int i=0; i<mixtureElem.Length;i++){
            if(mixtureElem[i]==0 && !found){
                mixtureElem[i]=IDEl;
                FindObjectOfType<AudioManager>().Play("Cald1");
                cont++;
                i++;
                if(cont>=2){buttonMix.SetActive(true);}
                found=true;
                return;
            }
        }
    }

    public void sendCook(){
        mixDT.cookMix(mixtureElem);
        FindObjectOfType<AudioManager>().Play("Cald2");
        ResetMix();
    }

    public void ResetMix(){
        cont=0;
        for(int i=0; i<mixtureElem.Length;i++){
            if(mixtureElem[i]!=0){
                mixtureElem[i]=0;
            }
        }
        buttonMix.SetActive(false);
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
