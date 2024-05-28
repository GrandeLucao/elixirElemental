using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixture
{
    public int[] requiredEl;
    public int mixId;
    public string name;

    public Mixture(int mixId, string name, int[] requiredEl){
        this.requiredEl=requiredEl;
        this.mixId=mixId;
        this.name=name;
    }


}
