using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed) return;

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4f + transform.localScale.x / 2f;
            float rightBorder = 4f - transform.localScale.x / 2f;

            if(mousePos.x < leftBorder) mousePos.x = leftBorder;
            if(mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }

        if (Input.GetMouseButtonDown(0)) Drag();
        if (Input.GetMouseButtonUp(0)) Drop();
    }

    void Drag()
    {
        isDrag = true;
        rigidbody2D.simulated = false;
    }

    void Drop()
    {
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;

        GameObject Temp = GameObject.FindWithTag("GameManager");
        if(Temp != null )
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }
   
}






