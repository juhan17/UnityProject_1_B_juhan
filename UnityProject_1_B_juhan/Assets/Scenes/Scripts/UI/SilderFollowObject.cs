using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderFollowObject : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null && slider != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offset);

            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            slider.transform.localPosition = canvasPos;
        }
    }
}
