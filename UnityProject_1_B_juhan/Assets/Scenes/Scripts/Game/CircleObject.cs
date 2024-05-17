using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    public int index;

    void Awake()
    {
        isUsed = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
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

    public void Used()
    { 
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)
            return;

        if (collision.gameObject.tag == "Fruit")
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();

            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {

                    GameObject Temp = GameObject.FindWithTag("GameManager");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }

                    Destroy(temp.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }

}






