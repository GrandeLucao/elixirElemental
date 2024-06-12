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
    public GameObject errorButton;
    
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
            gameController.instance.TimeLeft=60f; 
            Debug.Log("Obrigado por fazer "+client.getElemName);  
            clientID++;
            ChooseMix();
        }else{
            FailedMix();
        }
    }

    public void FailedMix(){
            FindObjectOfType<AudioManager>().Play("error");
            errorButton.GetComponent<Animator>().Play("error");
            gameController.instance.TimeLeft-=15f;


    }

}
