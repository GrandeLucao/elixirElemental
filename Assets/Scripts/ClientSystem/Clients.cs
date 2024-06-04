using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clients : MonoBehaviour
{
    public MixData mixDT;  
    public int clientID=0;  
    
    void Start()
    {
        ChooseMix();
    }


    void Update()
    {
        
    }

    public void ChooseMix(){
        int chooseID=Random.Range(0,10);
        Debug.Log(chooseID);
        Mixture client=mixDT.GetMix(chooseID);
        Debug.Log(client.getElemName);       

    }

    public void CompareMix(int[] playaMix){
        if(mixDT.isSameMix(playaMix, client.getElem)){
            //gamecontroller reset timer, increase money, etc
            //message from client
        }
    }

    //REset timer on gameCont,select mixture
}
