using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualPad : MonoBehaviour
{
    public float MaxLength = 70;
    public bool is4DPad = false;
    GameObject player;
    Vector2 defPos;
    Vector2 downPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        defPos = GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PadDown()
    {
        downPos = Input.mousePosition;
    }

    public void PadDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 newTapPos = mousePosition - downPos;

        if (is4DPad == false)
        {
            newTapPos.y = 0;
        }

        Vector2 axis = newTapPos.normalized;
        float len = Vector2.Distance(defPos, newTapPos);
        if (len > MaxLength)
        {
            newTapPos.x = axis.x * MaxLength;
            newTapPos.y = axis.y * MaxLength;
        }

        GetComponent<RectTransform>().localPosition = newTapPos;
        PlayerController plcnt = player.GetComponent<PlayerController>();
        plcnt.SetAxis(axis.x, axis.y);
    }

    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = defPos;
        PlayerController plcnt = player.GetComponent<PlayerController>();
        plcnt.SetAxis(0, 0);
    }
}
