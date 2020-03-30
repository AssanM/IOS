using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reel : MonoBehaviour
{
    public bool spin;
    public Text _txt;
    private string txt_ = string.Empty;
    //Speed That Reel Will Spin
    int speed;

    // Use this for initialization
    void Start()
    {
        spin = false;
        speed = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            foreach (Transform image in transform)//This Targets All Children Objects Of The Main Parent Object
            {
                //Direction And Speed Of Movement
                image.transform.Translate(Vector3.down * Time.smoothDeltaTime * speed, Space.World);

                //Once The Image Moves Below A Certain Point, Reset Its Position To The Top
                if (image.transform.position.y <= 0) { image.transform.position = new Vector3(image.transform.position.x, image.transform.position.y + 7200, image.transform.position.z); }//4000
            }
        }
    }

    //Once The Reel Finishes Spinning The Images Will Be Placed In A Random Position
    public void RandomPosition()
    {
        List<int> parts = new List<int>();
        List<int> middlePart = new List<int>();
        //Add All Of The Values For The Original Y Postions 
        /*parts.Add(200);
        parts.Add(100);
        parts.Add(0);
        parts.Add(-100);
        parts.Add(-200);
        parts.Add(-300);
        parts.Add(-400);
        parts.Add(-500);
        parts.Add(-600);
        parts.Add(-700);
        parts.Add(-800);
        parts.Add(-900);
        parts.Add(-1000);
        parts.Add(-1100);
        parts.Add(-1200);
        parts.Add(-1300);
        parts.Add(-1400);
        parts.Add(-1500);
        parts.Add(-1600);
        parts.Add(-1700);
        parts.Add(-1800);
        parts.Add(-1900);
        parts.Add(-2000);
        parts.Add(-2100);
        parts.Add(-2200);
        parts.Add(-2300);
        parts.Add(-2400);
        parts.Add(-2500);
        parts.Add(-2600);
        parts.Add(-2700);
        parts.Add(-2800);
        parts.Add(-2900);
        parts.Add(-3000);
        parts.Add(-3100);
        parts.Add(-3200);
        parts.Add(-3300);
        parts.Add(-3400);
        parts.Add(-3500);
        parts.Add(-3600);
        parts.Add(-3700);*/
        parts.Add(360);
        parts.Add(180);
        parts.Add(0);
        parts.Add(-180);
        parts.Add(-360);
        parts.Add(-540);
        parts.Add(-720);
        parts.Add(-900);
        parts.Add(-1080);
        parts.Add(-1260);
        parts.Add(-1440);
        parts.Add(-1620);
        parts.Add(-1800);
        parts.Add(-1980);
        parts.Add(-2160);
        parts.Add(-2340);
        parts.Add(-2520);
        parts.Add(-2700);
        parts.Add(-2880);
        parts.Add(-3060);
        parts.Add(-3240);
        parts.Add(-3420);
        parts.Add(-3600);
        parts.Add(-3780);
        parts.Add(-3960);
        parts.Add(-4140);
        parts.Add(-4320);
        parts.Add(-4500);
        parts.Add(-4680);
        parts.Add(-4860);
        parts.Add(-5040);
        parts.Add(-5220);
        parts.Add(-5400);
        parts.Add(-5580);
        parts.Add(-5760);
        parts.Add(-5940);
        parts.Add(-6120);
        parts.Add(-6300);
        parts.Add(-6480);
        parts.Add(-6660);

        foreach (Transform image in transform)
        {

                int rand = Random.Range(0, parts.Count);
                //The "transform.parent.GetComponent<RectTransform>().transform.position.y" Allows It To Adjust To The Canvas Y Position
                image.transform.position = new Vector3(image.transform.position.x, parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y, image.transform.position.z);
                parts.RemoveAt(rand);
        }
        _txt.text = txt_;
    }

    public void AlignMiddle(string colorToAlign)
    {
        List<int> middlePart = new List<int>();
        List<int> parts = new List<int>();

        //Add All Of The Values For The Original Y Postions 
        parts.Add(200);
        parts.Add(100);
        middlePart.Add(0);//0 Is The Middle Position
        parts.Add(-100);
        parts.Add(-200);
        parts.Add(-300);

        foreach (Transform image in transform)
        {
            if (image.name.Equals(colorToAlign) == true && middlePart.Count > 0)
            {
                int rand = Random.Range(0, middlePart.Count);
                //The "transform.parent.GetComponent<RectTransform>().transform.position.y" Allows It To Adjust To The Canvas Y Position
                image.transform.position = new Vector3(image.transform.position.x, middlePart[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y, image.transform.position.z);
                middlePart.RemoveAt(rand);
            }
            else
            {
                int rand = Random.Range(0, parts.Count);
                //The "transform.parent.GetComponent<RectTransform>().transform.position.y" Allows It To Adjust To The Canvas Y Position
                image.transform.position = new Vector3(image.transform.position.x, parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y, image.transform.position.z);
                parts.RemoveAt(rand);
            }
        }
    }

}
