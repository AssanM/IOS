using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnStartClick : MonoBehaviour
{
    public Image img;

    public void ChangeColor()
    {
        img.GetComponent<Image>().color = Color.black;
    }
}
