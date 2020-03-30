using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _txt;
    public Image _img;
    public void GetSizing()
    {
        var _w=_img.sprite.rect.width;
        var _h = _img.sprite.rect.height;
        _txt.text = "Width:" + _w + "; Height:" + _h;
    }

}
