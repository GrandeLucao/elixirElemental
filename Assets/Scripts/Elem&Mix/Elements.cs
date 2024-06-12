using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements
{
    public int id;
    public string name;
    public string desc;
    
    public Elements(int id, string name, string desc){
        this.id=id;
        this.name=name;
        this.desc=desc;
    }

    public Elements(Elements elem){
        this.id=elem.id;
        this.name=elem.name;
        this.desc=elem.desc;
    }

    public int getElemID
    {
        get{return id;}
    }
    
    public string getElemName
    {
        get{return name;}
    }

    public string getElemDesc
    {
        get{return desc;}
    }
    
}
