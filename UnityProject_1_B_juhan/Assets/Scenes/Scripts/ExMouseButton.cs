using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI를 사용하기위해 추가

public class ExMouseButton : MonoBehaviour
{
    public int Hp = 100;
    public Text textUI;            //UI 글씨 문자열 추가

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()      //매 프레임마다 호출 된다.
    {
        //Debug.Log("체력 : " + Hp);

        textUI.text = "체력 :" + Hp.ToString();   //UI에 체력 표시

        if (Input.GetMouseButtonDown(0))  //마우스 입력이 들어왔을때
        {
            Hp -= 10;
            Debug.Log("체력 : " + Hp);
            if (Hp <= 0)   //Hp가 0이하로 내려가면
            {
                textUI.text = "체력 :" + Hp.ToString();
                Destroy(gameObject);  //이 오브젝트를 파괴한다는 함수
            }
        }

    }
}
