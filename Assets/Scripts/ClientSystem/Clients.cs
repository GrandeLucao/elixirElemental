using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clients : MonoBehaviour
{
    public MixData mixDT;  
    public int clientID=0;
    Mixture client;
    public Text order;
    
    void Start()
    {
        ChooseMix();
    }


    void Update()
    {
        
    }

    public void ChooseMix(){
        int chooseID;  
        if(clientID==0){chooseID=0;}else{
        chooseID=Random.Range(0,mixDT.mixes.Count);
        }

        client=mixDT.GetMix(chooseID);
        order.text=("Preciso de "+client.getElemName);
        gameController.instance.TimerOn=true;  

    }

    public void CompareMix(int[] playaMix){
        if(mixDT.isSameMix(playaMix, client.getElem)){
            gameController.instance.TimerOn=false; 
            gameController.instance.TimeLeft=200f; 
            Debug.Log("Obrigado por fazer "+client.getElemName);  
            clientID++;
            ChooseMix();
        }else{
            Debug.Log("Ei seu panaca, eu pedi "+client.getElemName+"."); 
            gameController.instance.TimeLeft-=15f;

        }
    }

}
