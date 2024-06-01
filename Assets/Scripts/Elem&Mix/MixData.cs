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
            new Mixture(0,"Agua",new int[]{2,3,0})


        };
    }

    public void cookMix(int[] mixReady)
    {
        foreach(var mix in mixes){
            //int[] mixDatab=mix.getElem;
            if(isSameMix(mixReady, mix.getElem))
            {
                Debug.Log("DEu boa"+ mix.getElemName.ToString());
            }
            
            Debug.Log(mix.getElemName.ToString());
            Debug.Log(mix.getElem.ToString());
        }
        //foreach(var mix in mixReady){Debug.Log(mix.ToString());}

    }

    bool isSameMix(int[] playaMix, int[] dtMix)
    {
        if(playaMix.Length!=dtMix.Length){return false;}

        if(playaMix.Equals(dtMix)){
            return true;
        }

        return false;

    }

    

}
