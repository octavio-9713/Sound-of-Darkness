using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    public VictoryDefeatManager vdm;
    private void OnTriggerEnter(Collider other)
    {
        print("entre");
        if(other.tag == "Player")
        {
            print("entre2");
            vdm.didIWin = true;
        }
    }
}
