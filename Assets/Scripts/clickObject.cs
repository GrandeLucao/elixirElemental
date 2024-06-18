using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickObject : MonoBehaviour
{
    public MixData mixDT;
    public ElemData elemDT;
    public int[] mixtureElem;
    public GameObject frasco1,frasco2,frasco3,frasco4, frasco5,frasco6,frasco7;
    public GameObject buttonMix,buttonRemove;
    public int cont=0;
    public Text elems;

    void Update()
    {
            if(Input.GetMouseButtonDown(0) && cont<10){
                RaycastHit hit;
                if(frasco1==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote1");
                    frasco1.GetComponent<Animator>().Play("becker1");
                    canCook(1);
                                    }
                if(frasco2==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote2");
                    frasco2.GetComponent<Animator>().Play("becker2");
                    canCook(2);                    
                }
                if(frasco3==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote3");
                    frasco3.GetComponent<Animator>().Play("becker3");
                    canCook(3);                    
                }
                if(frasco4==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote4");
                    frasco4.GetComponent<Animator>().Play("becker4");
                    canCook(4);                    
                }
                if(frasco5==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote5");
                    frasco5.GetComponent<Animator>().Play("becker2");
                    canCook(5);                    
                }
                if(frasco6==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote6");
                    frasco6.GetComponent<Animator>().Play("becker6");
                    canCook(6);                    
                }
                if(frasco7==getClickedObject(out  hit)){
                    FindObjectOfType<AudioManager>().Play("pote7");
                    frasco7.GetComponent<Animator>().Play("becker7");
                    canCook(7);                    
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
                DisplayElems(mixtureElem[i]);
                cont++;
                i++;
                if(cont>=2){buttonMix.SetActive(true);}
                if(cont>=1){buttonRemove.SetActive(true);}
                found=true;
                return;
            }
        }
    }

    public void removeElem()
    {
        for(int i=mixtureElem.Length-1; i>=0;i--){
            if(mixtureElem[i]!=0){
                mixtureElem[i]=0;
                UndisplayElem();
                cont--;
                i--;
                if(cont<2){buttonMix.SetActive(false);}
                if(cont<1){buttonRemove.SetActive(false);}
                return;
            }
        }
    }

    public void sendCook(){
        int count=0;
        for(int i=0; i<mixtureElem.Length;i++){
            if(mixtureElem[i]!=0){count++;}
        }
        int[] mixToSend=mixtureElem;
        System.Array.Resize(ref mixToSend,count);
        mixDT.cookMix(mixToSend);
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
        elems.text=("");
        buttonMix.SetActive(false);
        buttonRemove.SetActive(false);
    }

    public void DisplayElems(int ID){   
            elems.text+=(elemDT.GetNameByID(ID));
    }

    public void UndisplayElem(){ 
            string newText="";  
            elems.text=("");
            foreach(var mix in mixtureElem){
                if(mix!=0){
                    newText+=elemDT.GetNameByID(mix);
                }
            }
            elems.text=newText;
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
