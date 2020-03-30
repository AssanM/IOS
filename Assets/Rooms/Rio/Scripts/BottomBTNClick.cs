using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public void BtnPlus(string text)
    {
        var txt=transform.Find("Bet").GetComponent<Text>();
        txt.text = "100";
    }
}
