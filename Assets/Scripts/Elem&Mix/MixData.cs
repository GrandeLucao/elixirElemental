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
            new Mixture(0,"Agua",new int[]{2,3,0}),
            new Mixture(1,"caca",new int[]{2,3,0}),
            new Mixture(2,"cece",new int[]{2,3,0}),
            new Mixture(3,"cici",new int[]{2,3,0}),
            new Mixture(4,"coco",new int[]{2,3,0}),
            new Mixture(5,"cucu",new int[]{2,3,0}),
            new Mixture(6,"arara",new int[]{2,3,0}),
            new Mixture(7,"erere",new int[]{2,3,0}),
            new Mixture(8,"iriri",new int[]{2,3,0}),
            new Mixture(9,"ororo",new int[]{2,3,0}),
            new Mixture(10,"ururu",new int[]{2,3,0})


        };
    }

    public void cookMix(int[] mixReady)
    {
        foreach(var mix in mixes){
            if(isSameMix(mixReady, mix.getElem))
            {
                Debug.Log("DEu boa"+ mix.getElemName.ToString());
            }
        }

    }

    public bool isSameMix(int[] playaMix, int[] dtMix)
    {
        if(playaMix.Length!=dtMix.Length){Debug.Log("DEu ruim pacas");return false;}

        System.Array.Sort(playaMix);
        System.Array.Sort(dtMix);

        for(var i=0;i<playaMix.Length;i++){
            if(playaMix[i]!=dtMix[i])
            {
                Debug.Log("DEu ruim");
                return false;
            }
        }
        return true;
    }

    public Mixture GetMix(int cliID)
    {
        try{
            foreach(var mix in mixes){
                if(cliID==mix.getElemID){return mix;}
            }
            return null;
        }

        catch (System.InvalidCastException ex){
            Debug.Log("Invalid cast");
            return null;
        }

    }

    

}
