using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Reel[] reel;
    public Image[] WinFrame;
    bool startSpin;
    public string color;
    public AudioSource SpinLoop;
    public AudioSource SpinLoopStop;
    public AudioSource btnclick;
    public Image img;
    public Text _Bettxt;
    public Text _Linetxt;
    public Text _MainLine;
    public Text _ttxt;
    private string _text = string.Empty;
    private Image[] sprites;
    public AudioSource _winSound;
    public AudioSource _BigwinSound;
    public Text _bet;
    public Text _line;
    public Text _coin;
    public Text _Wins;

    // Use this for initialization
    void Start()
    {
        startSpin = false;
        foreach (var f in WinFrame)
        {
            //f.enabled = false;
            f.color = Color.white;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!startSpin)//Prevents Interference If The Reels Are Still Spinning
        {
            if (Input.GetKeyDown(KeyCode.K))//The Input That Starts The Slot Machine
            {
                startSpin = true;
                StartCoroutine(Spinning());
            }
        }
    }
    public void StartSpining()
    {
        if (!startSpin)//Prevents Interference If The Reels Are Still Spinning
        {            
                startSpin = true;
                StartCoroutine(Spinning());            
        }
    }
    public void MaxBetting()
    {
        _Bettxt.text = "90";
        _Linetxt.text="10";
        _MainLine.text="10";
        if (!startSpin)//Prevents Interference If The Reels Are Still Spinning
        {
            startSpin = true;
            StartCoroutine(Spinning());
        }
    }
    IEnumerator Spinning()
    {
        foreach (var f in WinFrame)
        {
            f.enabled = false;
            f.color = Color.white;
        }
        foreach (Reel spinner in reel)
        {
            //Tells Each Reel To Start Spnning
            spinner.spin = true;
        }
        SpinLoop.Play();
        _text = string.Empty;
        List<string> winstring = new List<string>();
        var _txtpos = string.Empty;
        for (int i = 0; i < reel.Length; i++)
        {
            //Allow The Reels To Spin For A Random Amout Of Time Then Stop Them
            
            yield return new WaitForSeconds(Random.Range(1, 2));
            reel[i].spin = false;
            reel[i].RandomPosition();
            var _n = reel[i].GetComponentsInChildren<Image>();
            foreach (var n_ in _n)
            {
                var _nn = n_;
                var _p = _nn.gameObject.GetComponent<RectTransform>().position;
                
                var nn = _nn.sprite.name;
                if (_p.y > 259 && _p.y < 461 && !_nn.name.Contains("baraban") )
                {
                    
                    var _position = _p.y;
                   // _text += i + "--" + nn + " :" + _position + "\r\n";
                    var _posID = 0;
                    switch (_position)
                    {
                        case 260:
                            _posID=3;
                            break;
                        case 360:
                            _posID = 2;
                            break;
                        case 460:
                            _posID = 1;
                            break;
                    }
                    winstring.Add(i + ":" + _posID + ":" + nn);
                }
                if (_p.y > 320 && _p.y < 690 &&  !_nn.name.Contains("baraban"))
                {
                    var _position = _p.y;
                    _text += i + "--" + nn + " :" + _position + "\r\n";
                    var _posID = 0;
                    switch (_position)
                    {
                        case 325:
                            _posID = 3;
                            break;
                        case 505:
                            _posID = 2;
                            break;
                        case 685:
                            _posID = 1;
                            break;
                    }
                    winstring.Add(i + ":" + _posID + ":" + nn);
                }

            }
           // _ttxt.text = _text;
            //reel[i].AlignMiddle(color);
        }
        
        //Allows The Machine To Be Started Again
        startSpin = false;
        SpinLoop.Stop();
        SpinLoopStop.Play();
        GetLines(winstring);
        
    }
    void GetLines(List<string> _lines)
    {
        var _cnt = 0;
        foreach (var o in _lines)
        {
            if (o.StartsWith("0"))
            {
                _cnt++;
            }
        }
        if (_cnt < 3)
        {
            if (_cnt == 0)
            {
                _lines.Add("0:1:0");
                _lines.Add("0:2:0");
                _lines.Add("0:3:0");
            }
            if (_cnt == 1)
            {
                foreach (var o in _lines)
                {
                
                        if (o.StartsWith("0:1"))
                        {
                            _lines.Add("0:2:0");
                            _lines.Add("0:3:0");
                        }
                        if (o.StartsWith("0:2"))
                        {
                            _lines.Add("0:1:0");
                            _lines.Add("0:3:0");
                        }
                        if (o.StartsWith("0:3"))
                        {
                            _lines.Add("0:2:0");
                            _lines.Add("0:1:0");
                        }
                }
            }
            if (_cnt == 2)
            {
                var _nullCnt_ = 0;
                foreach (var o in _lines)
                {

                    if (o.StartsWith("0:1"))
                    {
                        _nullCnt_+=1;
                    }
                    if (o.StartsWith("0:2"))
                    {
                        _nullCnt_+=2;
                    }
                    if (o.StartsWith("0:3"))
                    {
                        _nullCnt_+=3;
                    }
                }
                switch (_nullCnt_)
                {
                    case 3:
                        _lines.Add("0:3:0");
                        break;
                    case 4:
                        _lines.Add("0:2:0");
                        break;
                    case 5:
                        _lines.Add("0:1:0");
                        break;
                }
            }

        }
        var _ttt = string.Empty;
        var _lines2 = _lines.OrderBy(q => q).ToList();
        List<int> wincoin = new List<int>();
        foreach (var j in _lines2)
        {
            _ttt += j + "\r\n";
            var _sName = j.Substring(4);
            var _sId = 0;
            switch (_sName)
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
                    _sId = 11;
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
                case "0":
                    _sId = 20;
                    break;
            }
            if (_sId != 0)
                wincoin.Add(_sId);
        }
        if (wincoin.Count != 0)
        {
            WinLines(wincoin);

            wincoin.Clear();
        }
        _ttxt.text = _ttt;
    }
    void WinLines(List<int> _WinsL)
    {
        
        var bet_ = int.Parse(_bet.text);
        var line_ = int.Parse(_line.text);
        int _winValue = 0;
        int bigWin = 0;
        //1 line
        for (int i = 1; i < 14; i++)
        {
            //1 line
            var _lin1 = 0;
            if (_WinsL[1] == i && _WinsL[4] == i)
            {
                _lin1 = (bet_ * TwoLines(i));
                if (_lin1 != 0)
                { WinFrame[1].enabled = WinFrame[4].enabled = true;
                    WinFrame[1].color = WinFrame[4].color =  Color.blue;
                }
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i)
            {
                _lin1 = (bet_ * ThreeLines(i));
                if (_lin1 != 0)
                {
                    WinFrame[1].enabled = WinFrame[4].enabled = WinFrame[7].enabled = true;
                    WinFrame[1].color = WinFrame[4].color = WinFrame[7].color = Color.blue;
                }
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i)
            {
                _lin1 = (bet_ * FourLines(i));
                if (_lin1 != 0)
                {
                    WinFrame[1].enabled = WinFrame[4].enabled = WinFrame[7].enabled = WinFrame[10].enabled = true;
                    WinFrame[1].color = WinFrame[4].color = WinFrame[7].color = WinFrame[10].color = Color.blue;
                }
            }
            if (_WinsL[1] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i && _WinsL[13] == i)
            {
                _lin1 = (bet_ * FiveLines(i));
                if (_lin1 != 0)
                {
                    WinFrame[1].enabled = WinFrame[4].enabled = WinFrame[7].enabled = WinFrame[10].enabled = WinFrame[13].enabled = true;
                    WinFrame[1].color = WinFrame[4].color = WinFrame[7].color = WinFrame[10].color = WinFrame[13].color= Color.blue;
                }

                }
            _winValue += _lin1;
            if (line_ > 1)
            {
                var _lin2 = 0;
                //2 line
                if (_WinsL[0] == i && _WinsL[3] == i)
                {
                    _lin2 = (bet_ * TwoLines(i));
                    if (_lin2 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = true;
                        WinFrame[0].color = WinFrame[3].color =  Color.red;
                    }
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i)
                {
                    _lin2 = (bet_ * ThreeLines(i));
                    if (_lin2 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[6].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[6].color= Color.red;
                    }
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i)
                {
                    _lin2 = (bet_ * FourLines(i));
                    if (_lin2 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[6].enabled = WinFrame[9].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[6].color = WinFrame[9].color= Color.red;
                    }
                    }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i && _WinsL[12] == i)
                {
                    _lin2 = (bet_ * FiveLines(i));
                    if (_lin2 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[6].enabled = WinFrame[9].enabled = WinFrame[12].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[6].color = WinFrame[9].color = WinFrame[12].color= Color.red;
                    }
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
                    if (_lin3 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = Color.green;
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i)
                {
                    _lin3 = (bet_ * ThreeLines(i));
                    if (_lin3 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[8].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[8].color= Color.green;
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i)
                {
                    _lin3 = (bet_ * FourLines(i));
                    if (_lin3 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[8].enabled = WinFrame[11].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[8].color = WinFrame[11].color= Color.green;
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i && _WinsL[14] == i)
                {
                    _lin3 = (bet_ * FiveLines(i));
                    if (_lin3 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[8].enabled = WinFrame[11].enabled = WinFrame[14].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[8].color = WinFrame[11].color = WinFrame[14].color= Color.green;
                    }
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
                    if (_lin4 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[4].enabled = true;
                        WinFrame[0].color = WinFrame[4].color =  Color.yellow;
                    }
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i)
                {
                    _lin4 = (bet_ * ThreeLines(i));
                    if (_lin4 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[4].enabled = WinFrame[8].enabled = true;
                        WinFrame[0].color = WinFrame[4].color = WinFrame[8].color= Color.yellow;
                    }
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i && _WinsL[10] == i)
                {
                    _lin4 = (bet_ * FourLines(i));
                    if (_lin4 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[4].enabled = WinFrame[8].enabled = WinFrame[10].enabled = true;
                        WinFrame[0].color = WinFrame[4].color = WinFrame[8].color = WinFrame[10].color=Color.yellow;
                    }
                }
                if (_WinsL[0] == i && _WinsL[4] == i && _WinsL[8] == i && _WinsL[10] == i && _WinsL[12] == i)
                {
                    _lin4 = (bet_ * FiveLines(i));
                    if (_lin4 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[4].enabled = WinFrame[8].enabled = WinFrame[10].enabled = WinFrame[12].enabled = true;
                        WinFrame[0].color = WinFrame[4].color = WinFrame[8].color = WinFrame[10].color = WinFrame[12].color= Color.yellow;
                    }
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
                    if (_lin5 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = true;
                        WinFrame[2].color = WinFrame[4].color =  new Color(0.99f,0.6f,0.87f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i)
                {
                    _lin5 = (bet_ * ThreeLines(i));
                    if (_lin5 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[6].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[6].color= new Color(0.99f, 0.6f, 0.87f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i && _WinsL[10] == i)
                {
                    _lin5 = (bet_ * FourLines(i));
                    if (_lin5 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[6].enabled = WinFrame[10].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[6].color = WinFrame[10].color= new Color(0.99f, 0.6f, 0.87f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[6] == i && _WinsL[10] == i && _WinsL[14] == i)
                {
                    _lin5 = (bet_ * FiveLines(i));
                    if (_lin5 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[6].enabled = WinFrame[10].enabled = WinFrame[14].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[6].color = WinFrame[10].color = WinFrame[14].color= new Color(0.99f, 0.6f, 0.87f);
                    }
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
                    if (_lin6 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[5].enabled = true;
                        WinFrame[1].color = WinFrame[5].color = new Color(0.73f, 0.98f, 0.4f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i)
                {
                    _lin6 = (bet_ * ThreeLines(i));
                    if (_lin6 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[5].enabled = WinFrame[8].enabled = true;
                        WinFrame[1].color = WinFrame[5].color = WinFrame[8].color= new Color(0.73f, 0.98f, 0.4f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i)
                {
                    _lin6 += (bet_ * FourLines(i));
                    if (_lin6 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[5].enabled = WinFrame[8].enabled = WinFrame[11].enabled = true;
                        WinFrame[1].color = WinFrame[5].color = WinFrame[8].color = WinFrame[11].color= new Color(0.73f, 0.98f, 0.4f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[5] == i && _WinsL[8] == i && _WinsL[11] == i && _WinsL[13] == i)
                {
                    _lin6 = (bet_ * FiveLines(i));
                    if (_lin6 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[5].enabled = WinFrame[8].enabled = WinFrame[11].enabled = WinFrame[13].enabled = true;
                        WinFrame[1].color = WinFrame[5].color = WinFrame[8].color = WinFrame[11].color = WinFrame[13].color= new Color(0.73f, 0.98f, 0.4f);
                    }
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
                    if (_lin7 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[3].enabled = true;
                        WinFrame[1].color = WinFrame[3].color =  new Color(0.98f, 0.75f, 0.68f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i)
                {
                    _lin7 = (bet_ * ThreeLines(i));
                    if (_lin7 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[3].enabled = WinFrame[6].enabled = true;
                        WinFrame[1].color = WinFrame[3].color = WinFrame[6].color = new Color(0.98f, 0.75f, 0.68f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i)
                {
                    _lin7 = (bet_ * FourLines(i));
                    if (_lin7 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[3].enabled = WinFrame[6].enabled = WinFrame[9].enabled = true;
                        WinFrame[1].color = WinFrame[3].color = WinFrame[6].color = WinFrame[9].color = new Color(0.98f, 0.75f, 0.68f);
                    }
                }
                if (_WinsL[1] == i && _WinsL[3] == i && _WinsL[6] == i && _WinsL[9] == i && _WinsL[13] == i)
                {
                    _lin7 = (bet_ * FiveLines(i));
                    if (_lin7 != 0)
                    {
                        WinFrame[1].enabled = WinFrame[3].enabled = WinFrame[6].enabled = WinFrame[9].enabled = WinFrame[13].enabled = true;
                        WinFrame[1].color = WinFrame[3].color = WinFrame[6].color = WinFrame[9].color = WinFrame[13].color = new Color(0.98f, 0.75f, 0.68f);
                    }
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
                    if (_lin8 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = new Color(0.66f, 0.85f, 0.88f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i)
                {
                    _lin8 = (bet_ * ThreeLines(i));
                    if (_lin8 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[7].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[7].color= new Color(0.66f, 0.85f, 0.88f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i && _WinsL[9] == i)
                {
                    _lin8 = (bet_ * FourLines(i));
                    if (_lin8 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[7].enabled = WinFrame[9].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[7].color = WinFrame[9].color= new Color(0.66f, 0.85f, 0.88f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[5] == i && _WinsL[7] == i && _WinsL[9] == i && _WinsL[12] == i)
                {
                    _lin8 = (bet_ * FiveLines(i));
                    if (_lin8 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[5].enabled = WinFrame[7].enabled = WinFrame[9].enabled = WinFrame[12].enabled = true;
                        WinFrame[2].color = WinFrame[5].color = WinFrame[7].color = WinFrame[9].color = WinFrame[12].color= new Color(0.66f, 0.85f, 0.88f);
                    }
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
                    if (_lin9 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = true;
                        WinFrame[0].color = WinFrame[3].color =  new Color(1f, 0.77f, 0.44f);
                    }
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i)
                {
                    _lin9 = (bet_ * ThreeLines(i));
                    if (_lin9 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[7].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[7].color = new Color(1f, 0.77f, 0.44f);
                    }
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i && _WinsL[11] == i)
                {
                    _lin9 = (bet_ * FourLines(i));
                    if (_lin9 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[7].enabled = WinFrame[11].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[7].color = WinFrame[11].color = new Color(1f, 0.77f, 0.44f);
                    }
                }
                if (_WinsL[0] == i && _WinsL[3] == i && _WinsL[7] == i && _WinsL[11] == i && _WinsL[14] == i)
                {
                    _lin9 = (bet_ * FiveLines(i));
                    if (_lin9 != 0)
                    {
                        WinFrame[0].enabled = WinFrame[3].enabled = WinFrame[7].enabled = WinFrame[11].enabled = WinFrame[14].enabled = true;
                        WinFrame[0].color = WinFrame[3].color = WinFrame[7].color = WinFrame[11].color = WinFrame[14].color = new Color(1f, 0.77f, 0.44f);
                    }
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
                    if (_lin10 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = true;
                        WinFrame[2].color = WinFrame[4].color =  new Color(1f, 0.7f, 1f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i)
                {
                    _lin10 = (bet_ * ThreeLines(i));
                    if (_lin10 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[7].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[7].color= new Color(1f, 0.7f, 1f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i)
                {
                    _lin10 = (bet_ * FourLines(i));
                    if (_lin10 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[7].enabled = WinFrame[10].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[7].color = WinFrame[10].color= new Color(1f, 0.7f, 1f);
                    }
                }
                if (_WinsL[2] == i && _WinsL[4] == i && _WinsL[7] == i && _WinsL[10] == i && _WinsL[12] == i)
                {
                    _lin10 = (bet_ * FiveLines(i));
                    if (_lin10 != 0)
                    {
                        WinFrame[2].enabled = WinFrame[4].enabled = WinFrame[7].enabled = WinFrame[10].enabled = WinFrame[12].enabled = true;
                        WinFrame[2].color = WinFrame[4].color = WinFrame[7].color = WinFrame[10].color = WinFrame[12].color= new Color(1f, 0.7f, 1f);
                    }
                }
                _winValue += _lin10;
            }
        }

        var coin_ = int.Parse(_coin.text);
        coin_ = coin_ - bet_ * line_;

        if (_winValue != 0)
        {
            _winSound.Play();
            coin_ = coin_ + _winValue;
            _Wins.text = "You Won : " + _winValue;
        }
        else
        {
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
