using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Randomize : MonoBehaviour
{
    public Sprite[] sprites;
    public float StopTime;
    public new AudioSource audio;
    public new GameObject StopBtn;
    public new GameObject startBtn;
    public Text _lines;
    private Sprite sp_;
    private string Res_;

    int timer = 5;
    // Update is called once per frame
    void Update()
    {
        
        RandomImage();        
    }
    void RandomImage()
    {
        var _SP= sprites[Random.Range(0, sprites.Length)];
        
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = _SP;
        sp_ = _SP;
        Res_ = sp_.name + "\r\n";
        
    }

    void EndRand()
    {
        enabled = false;
        
    }

    public void StopRand()
    {
        Invoke("EndRand", StopTime);
        audio.Stop();
    }
    public void StartRand()
    {   
        enabled = true;
        audio.Play();
        
        Invoke("EndRand", StopTime + 1);
        Invoke("StopSound", timer);
        
    }

    public void StopEmidiate()
    {
        Invoke("EndRand", 0);
        
        audio.Stop();
        enabled = false;
        timer = 5;
    }

    public void PlaySound()
    {
        audio.Play();
    }
    void StopSound()
    {
        audio.Stop();
        StopBtn.SetActive(false);
        startBtn.SetActive(true);
        //enabled = false;
    }

    
    

}
