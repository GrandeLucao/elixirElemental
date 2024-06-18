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
            new Mixture(0, "Água", new int[]{2, 3, 2}),                      // H2O
            new Mixture(1, "Reação Explosiva", new int[]{6, 2, 3,2}),       // Na + H2O
            new Mixture(2, "Sal de Cozinha", new int[]{6, 5}),            // NaCl
            new Mixture(3, "Substância Cáustica", new int[]{6,6, 3}),       // Na2O
            new Mixture(4, "Dióxido de Carbono", new int[]{1, 3,3}),        // CO2
            new Mixture(5, "Gás Inflamável", new int[]{1, 2,2,2,2}),            // CH4
            new Mixture(6, "Amoníaco", new int[]{4,2,2,2}),                  // NH3
            new Mixture(7, "Metano", new int[]{1, 2,2,2,2}),                    // CH4
            new Mixture(8, "Gás do Efeito Estufa", new int[]{1, 3,3}),      // CO2
            new Mixture(9, "Etanol", new int[]{1,1,2,2,2,2,2,3,2}),                 // C2H5OH
            new Mixture(10, "Carbonato de Cálcio", new int[]{7, 1, 3,3,3}),   // CaCO3
            new Mixture(11, "Cloreto de Cálcio", new int[]{7, 5,5})         // CaCl2
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
        client.FailedMix();


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
