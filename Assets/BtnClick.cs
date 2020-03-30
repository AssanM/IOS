using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;
    public Text _txt;
    public Text _MainLine;
    public Text _bet;
    public Text _line;
    public Text _coin;
    public Text _Wins;
    public AudioSource _winSound;
    public Image[] sprites;

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
    int Incrize(int _val)
    {
        int i = 0;
        if (_val<=10 && _val>0)
        {
            i = 1;
        }
        if (_val<=50 && _val>10)
        {
            i = 5;
        }
        else
        {
            i = 10;
        }
        return i;
        
    }

    public void LineMinus(string text)
    {
        audio.Play();

        var _value = int.Parse(_txt.text);
        if (_value > 1)
            _value = _value - 1;
        _txt.text = _value.ToString(); ;
        _MainLine.text= _value.ToString(); 
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
    public void OnButtonClick()
    {
       Wins();
    }

    void Wins()
    {
        var res_ = string.Empty;
        var i = 0;
        List<int> wincoin = new List<int>() ;

        foreach (var s in sprites)
        {
            var p = s.sprite;
            i++;
            var _sId = 0;
            if (p != null)
            {
                switch (s.sprite.name)
                {
                    case "bird":
                        _sId = 13;
                        break;
                    case "christ":
                        _sId = 12;
                        break;
                    case "Cocktail":
                        _sId = 8;
                        break;
                    case "drum":
                        _sId = 7;
                        break;
                    case "elephant":
                        _sId = 5;
                        break;
                    case "woman1_1":
                        _sId = 9;
                        break;
                    case "woman2_1":
                        _sId = 10;
                        break;
                    case "9":
                        _sId = 1;
                        break;
                    case "10":
                        _sId = 2;
                        break;
                    case "J":
                        _sId = 3;
                        break;
                    case "Q":
                        _sId = 4;
                        break;
                    case "K":
                        _sId = 5;
                        break;
                    case "A":
                        _sId = 6;
                        break;
                }
                if (_sId != 0)
                    wincoin.Add(_sId);
                res_ += i + "--" + _sId + ":" + s.sprite.name + "\r\n";
            }
        }
        //_Wins.text = res_;
        if (wincoin.Count != 0)
        {
            WinLines(wincoin);

            wincoin.Clear();
        }
    }
    void WinLines(List<int> _WinsL)
    {
        var bet_ = int.Parse(_bet.text);
        var line_ = int.Parse(_line.text);
        int _winValue = 0;
        //1 line
        for (int i = 1; i < 14; i++)
        {
            //1 line
            var _lin1 = 0;
            if (_WinsL[1] == i && _WinsL[4] == i)
            {
                _lin1 = (bet_ * TwoLines(i));
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i)
            {
                _lin1 = (bet_ * ThreeLines(i));
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i)
            {
                _lin1 = (bet_ * FourLines(i));
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i && _WinsL[13] == i)
            {
                _lin1 = (bet_ * FiveLines(i));
            }
            _winValue += _lin1;
            if (line_ > 1)
            {
                var _lin2 = 0;
                //2 line
                if (_WinsL[0] == i && _WinsL[3] == i)
                {
                    _lin2 = (bet_ * TwoLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i)
                {
                    _lin2 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i)
                {
                    _lin2 = (bet_ * FourLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i && _WinsL[12] == i)
                {
                    _lin2 = (bet_ * FiveLines(i));
                }
                _winValue += _lin2;
            }
            if (line_ > 2)
            {
                var _lin3 = 0;
                //3 line
                if (_WinsL[2] == i && _WinsL[5] == i)
                {
                    _lin3 = (bet_ * TwoLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i)
                {
                    _lin3 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i)
                {
                    _lin3 = (bet_ * FourLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i && _WinsL[14] == i)
                {
                    _lin3 = (bet_ * FiveLines(i));
                }
                _winValue += _lin3;
            }
            if (line_ > 3)
            {
                var _lin4 = 0;
                //4 line
                if (_WinsL[0] == i && _WinsL[4] == i)
                {
                    _lin4 = (bet_ * TwoLines(i));
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i)
                {
                    _lin4 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i && _WinsL[10] == i)
                {
                    _lin4 = (bet_ * FourLines(i));
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i && _WinsL[10] == i && _WinsL[12] == i)
                {
                    _lin4 = (bet_ * FiveLines(i));
                }
                _winValue += _lin4;
            }
            if (line_ > 4)
            {
                var _lin5 = 0;
                //5 line
                if (_WinsL[2] == i && _WinsL[4] == i)
                {
                    _lin5 = (bet_ * TwoLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i)
                {
                    _lin5 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i && _WinsL[10] == i)
                {
                    _lin5 = (bet_ * FourLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i && _WinsL[10] == i && _WinsL[14] == i)
                {
                    _lin5 = (bet_ * FiveLines(i));
                }
                _winValue += _lin5;
            }
            if (line_ > 5)
            {
                var _lin6 = 0;
                //6line
                if (_WinsL[1] == i && _WinsL[5] == i)
                {
                    _lin6 = (bet_ * TwoLines(i));
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i)
                {
                    _lin6 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i)
                {
                    _lin6 += (bet_ * FourLines(i));
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i && _WinsL[13] == i)
                {
                    _lin6 = (bet_ * FiveLines(i));
                }
                _winValue += _lin6;
            }
            if (line_ > 6)
            {
                var _lin7 = 0;
                //7 line
                if (_WinsL[1] == i && _WinsL[3] == i)
                {
                    _lin7 = (bet_ * TwoLines(i));
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i)
                {
                    _lin7 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i)
                {
                    _lin7 = (bet_ * FourLines(i));
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i && _WinsL[13] == i)
                {
                    _lin7 = (bet_ * FiveLines(i));
                }
                _winValue += _lin7;
            }
            if (line_ > 7)
            {
                var _lin8 = 0;
                //8line
                if (_WinsL[2] == i && _WinsL[5] == i)
                {
                    _lin8 = (bet_ * TwoLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i)
                {
                    _lin8 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i && _WinsL[9] == i)
                {
                    _lin8 = (bet_ * FourLines(i));
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i && _WinsL[9] == i && _WinsL[12] == i)
                {
                    _lin8 = (bet_ * FiveLines(i));
                }
                _winValue += _lin8;
            }
            if (line_ > 8)
            {
                var _lin9 = 0;
                //9line
                if (_WinsL[0] == i && _WinsL[3] == i)
                {
                    _lin9 = (bet_ * TwoLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i)
                {
                    _lin9 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i && _WinsL[11] == i)
                {
                    _lin9 = (bet_ * FourLines(i));
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i && _WinsL[11] == i && _WinsL[14] == i)
                {
                    _lin9 = (bet_ * FiveLines(i));
                }
                _winValue += _lin9;
            }
            if (line_ > 9)
            {
                var _lin10 = 0;
                //10line
                if (_WinsL[2] == i && _WinsL[4] == i)
                {
                    _lin10 = (bet_ * TwoLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i)
                {
                    _lin10 = (bet_ * ThreeLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i)
                {
                    _lin10 = (bet_ * FourLines(i));
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i && _WinsL[12] == i)
                {
                    _lin10 = (bet_ * FiveLines(i));
                }
                _winValue += _lin10;
            }
        }

        var coin_ = int.Parse(_coin.text);
        
        
        if (_winValue != 0)
        {
            _winSound.Play();
            coin_ = coin_ + _winValue;
            _Wins.text = "You Won : "+_winValue;
        }
        else
        {
            coin_ = coin_ - bet_ * line_;
            _Wins.text = "You Lose : " + bet_ * line_;
        }
        _coin.text = coin_.ToString();
    }
    int TwoLines(int _symbol)
    {
        int _value = 0;
        switch (_symbol)
        {
            case 1:
                _value = 4;
                break;
            case 2:
                _value = 0;
                break;
            case 3:
                _value = 0;
                break;
            case 4:
                _value = 0;
                break;
            case 5:
                _value = 0;
                break;
            case 6:
                _value = 0;
                break;
            case 7:
                _value = 0;
                break;
            case 8:
                _value = 0;
                break;
            case 9:
                _value = 0;
                break;
            case 10:
                _value = 4;
                break;
            case 11:
                _value = 4;
                break;
            case 12:
                _value = 20;
                break;
            case 13:
                _value = 40;
                break;
        }
        return _value;
    }
    int ThreeLines(int _symbol)
    {
        int _value = 0;
        switch (_symbol)
        {
            case 1:
                _value = 10;
                break;
            case 2:
                _value = 10;
                break;
            case 3:
                _value = 10;
                break;
            case 4:
                _value = 10;
                break;
            case 5:
                _value = 20;
                break;
            case 6:
                _value = 20;
                break;
            case 7:
                _value = 30;
                break;
            case 8:
                _value = 30;
                break;
            case 9:
                _value = 40;
                break;
            case 10:
                _value = 50;
                break;
            case 11:
                _value = 50;
                break;
            case 12:
                _value = 500;
                break;
            case 13:
                _value = 100;
                break;
        }
        return _value;
    }
    int FourLines(int _symbol)
    {
        int _value = 0;
        switch (_symbol)
        {
            case 1:
                _value = 50;
                break;
            case 2:
                _value = 50;
                break;
            case 3:
                _value = 50;
                break;
            case 4:
                _value = 50;
                break;
            case 5:
                _value = 100;
                break;
            case 6:
                _value = 100;
                break;
            case 7:
                _value = 150;
                break;
            case 8:
                _value = 150;
                break;
            case 9:
                _value = 200;
                break;
            case 10:
                _value = 250;
                break;
            case 11:
                _value = 250;
                break;
            case 12:
                _value = 5000;
                break;
            case 13:
                _value = 400;
                break;
        }
        return _value;
    }
    int FiveLines(int _symbol)
    {
        int _value = 0;
        switch (_symbol)
        {
            case 1:
                _value = 200;
                break;
            case 2:
                _value = 200;
                break;
            case 3:
                _value = 200;
                break;
            case 4:
                _value = 200;
                break;
            case 5:
                _value = 250;
                break;
            case 6:
                _value = 250;
                break;
            case 7:
                _value = 500;
                break;
            case 8:
                _value = 500;
                break;
            case 9:
                _value = 800;
                break;
            case 10:
                _value = 1500;
                break;
            case 11:
                _value = 1500;
                break;
            case 12:
                _value = 18000;
                break;
            case 13:
                _value = 10000;
                break;
        }
        return _value;
    }

}
