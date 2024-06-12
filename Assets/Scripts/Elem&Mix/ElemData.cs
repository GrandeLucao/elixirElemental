using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemData : MonoBehaviour
{
    public List<Elements> element=new List<Elements>();

    void Awake(){BuildDT();}    

    void BuildDT(){
        element=new List<Elements>()
        {
            new Elements(1,"Carbono","C"),
            new Elements(2,"Hidrogenio","H"),
            new Elements(3,"Oxigenio","O"),
            new Elements(4,"Calcio","Ca"),
            new Elements(5,"Cloro","Cl"),
            new Elements(6,"Sodio","Na"),
            new Elements(7,"Nitrogenio","N"),
        };
    }

    public string GetNameByID(int IDtoFind){
        foreach(var elem in element){
            if(IDtoFind==elem.getElemID){
                string elemName=elem.getElemDesc;
                return elemName;
            }
        }
        return null;
    }


    
}
