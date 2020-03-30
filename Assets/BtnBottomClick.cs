using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBottomClick : MonoBehaviour
{
    public AudioSource audio;
    public Text _txt;
    public Text _MainLine;
    public AudioSource _winSound;
    public void BtnPlus(string text)
    {
        audio.Play();
        var i = 0;
        var _value = int.Parse(_txt.text);
        if (_value < 90)
        {
            if (_value > 0)
            {
                if (_value <= 9)
                { i = 1; }
                else
                {
                    if (_value <= 45 && _value > 9)
                    { i = 5; }
                    else
                    {
                        i = 10;
                    }
                }
            }
        }
        _value = _value + i;
        _txt.text = _value.ToString(); ;
    }
    public void BtnMinus(string text)
    {
        audio.Play();
        var i = 0;
        var _value = int.Parse(_txt.text);
        if (_value > 1)
        {
            if (_value <= 11)
            { i = 1; }
            else
            {
                if (_value <= 55 && _value > 9)
                { i = 5; }
                else
                {
                    i = 10;
                }
            }
        }
        _value = _value - i;
        _txt.text = _value.ToString(); ;
    }
    public void LineMinus(string text)
    {
        audio.Play();

        var _value = int.Parse(_txt.text);
        if (_value > 1)
            _value = _value - 1;
        _txt.text = _value.ToString(); ;
        _MainLine.text = _value.ToString();
    }
    public void LinePlus(string text)
    {
        audio.Play();

        var _value = int.Parse(_txt.text);
        if (_value < 10)
            _value = _value + 1;
        _txt.text = _value.ToString(); ;
        _MainLine.text = _value.ToString();
    }
}
