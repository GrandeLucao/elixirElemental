using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixData : MonoBehaviour
{
    public Clients client;
    public List<Mixture> mixes=new List<Mixture>();
    
    void Awake(){BuildMDT();}

    void BuildMDT(){
        mixes=new List<Mixture>()
        {
            new Mixture(0,"Agua",new int[]{2,3,0}),
            new Mixture(1,"Dioxido de Cabono",new int[]{1,3,0}),
            new Mixture(2,"Metano",new int[]{1,2,0}),
            new Mixture(3,"Etanol",new int[]{1,2,3}),
            new Mixture(4,"Carbonato de Calcio",new int[]{4,1,3})
        };
    }

    public void cookMix(int[] mixReady)
    {
        foreach(var mix in mixes){
            if(isSameMix(mixReady, mix.getElem))
            {
                client.CompareMix(mix.getElem);
                return;
            }
        }

        //Dunno, explode here or something

    }

    public bool isSameMix(int[] playaMix, int[] dtMix)
    {
        if(playaMix.Length!=dtMix.Length){return false;}

        System.Array.Sort(playaMix);
        System.Array.Sort(dtMix);

        for(var i=0;i<playaMix.Length;i++){
            if(playaMix[i]!=dtMix[i])
            {
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
