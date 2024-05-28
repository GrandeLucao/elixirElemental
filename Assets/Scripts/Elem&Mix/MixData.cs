using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixData : MonoBehaviour
{
    public List<Mixture> mixes=new List<Mixture>();
    
    void Awake(){BuildMDT();}

    void BuildMDT(){
        mixes=new List<Mixture>()
        {
            new Mixture(0,"Agua",new int[]{2,3})


        };
    }
    

}
