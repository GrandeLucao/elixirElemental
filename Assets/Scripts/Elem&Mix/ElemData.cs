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
            new Elements(4,"Nitrogenio","N"),
            new Elements(5,"Cloro","Cl"),
            new Elements(6,"Sodio","Na"),
            new Elements(7,"Calcio","Ca"),
        };
        
        foreach(var elem in element){Debug.Log(elem.name.ToString());}
    }

    public Elements GetElemId(int id)
    {
        return element.Find(elem=> elem.id==id);
    }

    public Elements GetElemName(string name)
    {
        return element.Find(elem=> elem.name==name);
    }

    public Elements GetElemDesc(string desc)
    {
        return element.Find(elem=> elem.desc==desc);
    }
    
}
