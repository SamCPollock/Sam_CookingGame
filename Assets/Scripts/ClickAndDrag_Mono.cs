using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Plane = UnityEngine.Plane;

public class ClickAndDrag_Mono : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Debug.Log("CLICKED");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("UNCLICKED");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;


    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Plane plane = new Plane(UnityEngine.Vector3.up, transform.position);
            Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
            float distance;

            transform.position = ray.origin + ray.direction;
            if (plane.Raycast(ray, out distance))
            {
                transform.position = ray.origin + ray.direction * distance;
            }
            Debug.Log("DRAGGINS");

        }
    }
}
