using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class ShowRitual : MonoBehaviour
{

    public float radius = 50;
    public string pattern = "";
    public Sprite empty;
    public Sprite fire;
    public Sprite earth;
    public Sprite skull;
    public Sprite ice;
    public Sprite gold;
    public float width = 100;
    public float topBuffer = 100;
    public int ritualNo = 0;
    public int ritualsTotal = 5;
    private int elementNo = 0;
    private List<GameObject> objects = new List<GameObject>();

    // Use this for initialization
    //X = xcircle + (r* sine(angle))
    //Y = ycircle + (r* cosine(angle))
    public void Start()
    {

        elementNo = pattern.Length;
        float degree = 360 / elementNo;
        degree = Mathf.Deg2Rad * degree;

        for (int i = 0; i < elementNo; i++)
        {
            
            float X = radius * Mathf.Sin(degree * (i+1));
            float y = radius * Mathf.Cos(degree * (i+1));
            float moveWidth = (Screen.width / (ritualsTotal+1)) * ritualNo;

            GameObject clone = new GameObject("Name");
            clone.AddComponent<RectTransform>();
            clone.transform.parent = this.transform;
            objects.Add(clone);
            objects[i].transform.SetParent(this.transform, false);
            objects[i].AddComponent<Image>();
            objects[i].GetComponent<Image>().sprite = empty;
            //    ((empty, position, this.transform.localRotation));
            Vector3 position = new Vector3(0,0,0);
            position.x += width + X - Screen.height;
            position.y =+ y + this.width;
             objects[i].GetComponent<RectTransform>().localPosition = position;
            Vector3 Anchor = new Vector3(0, 0, 0);
            Anchor.x = - Screen.width/2 + width  +X + moveWidth; 
            Anchor.y = Screen.height/2 - topBuffer + y;
            objects[i].GetComponent<RectTransform>().anchoredPosition = Anchor;

            Vector2 size = new Vector2(50, 50);
            objects[i].GetComponent<RectTransform>().sizeDelta = size;
        }

        //add our event
        RitualAction temp;
        if (resouceManager.resourcePatterns.TryGetValue(pattern, out temp))
        {

            temp.isCast += listenForCast();
        }
    }
    public resouceManager.castEvent listenForCast()
    {

        return new resouceManager.castEvent(upDateDisplay);
    }
    public void upDateDisplay(bool cast)
    {
       
            for (int i = 0; i < objects.Count; i++)
            {
                switch ((resouceManager.resourceType)pattern[i])
                {
                    case resouceManager.resourceType.skull:
                        objects[i].GetComponent<Image>().sprite = skull;
                        break;
                    case resouceManager.resourceType.lava:
                        objects[i].GetComponent<Image>().sprite = fire;
                        break;
                    case resouceManager.resourceType.gold:
                        objects[i].GetComponent<Image>().sprite = gold;
                        break;
                    case resouceManager.resourceType.ice:
                        objects[i].GetComponent<Image>().sprite = ice;
                        break;
                    case resouceManager.resourceType.earth:
                        objects[i].GetComponent<Image>().sprite = earth;
                        break;
                    default:
                        break;
                }
            }
    }
}
    
