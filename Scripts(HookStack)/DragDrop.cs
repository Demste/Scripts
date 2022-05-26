using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragDrop : MonoBehaviour ,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerClickHandler
{
    private Camera cam;
    private Ray ray;
    private Transform selectedObject;
    private Plane plane;


    private Vector2 firstPos;
    private Vector2 lastPos;


    public Canvas canvas;


    private float click = 2f;



    private void Start() 
    {

        plane = new Plane(Vector3.up,new Vector3(0f,6f,0f));
        cam = Camera.main;
    }
    private void Update()
    {
        //if (dragging)
        //{
        //    if (selectedObject)
        //    {
        //        float distance = 0;
        //        if (plane.Raycast(ray, out distance))
        //        {
        //            selectedObject.transform.position = ray.GetPoint(distance);


        //        }
        //    }
        //}
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPos = eventData.position;
        Debug.Log("begin");

        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                selectedObject = hit.collider.transform;
                selectedObject.transform.DOMoveY(6f, 0.1f);
            }
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        print("drag");
        //lastPos = eventData.position;

        //float x = lastPos.x - firstPos.x;
        //x = Mathf.Clamp(x/8f,-10f,20f);

        //float z = lastPos.y - firstPos.y;
        //z = Mathf.Clamp(x / 8f, -10f, 20f);



        selectedObject.position += new Vector3(eventData.delta.x/50f,0f,eventData.delta.y/50f);



    }
    public void OnEndDrag(PointerEventData eventData)
    {
        print("enddrag");
        selectedObject.transform.position = new Vector3(selectedObject.position.x, 3f, selectedObject.position.z);

        selectedObject = null;
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
   
        if (click % 2 ==0)
        {
            print("firstPos");
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    selectedObject = hit.collider.transform;
                    selectedObject.transform.DOMoveY(6f, 0.1f);
                }
            }
            click++;
        }
       else if (click % 2 != 0)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    selectedObject = hit.collider.transform;

                    print("second click");
                    Vector3 newdir = new Vector3(eventData.position.x, selectedObject.position.y, eventData.position.y);

                    selectedObject.transform.DOMove(newdir, 1f);
                }
            }

        }
    }

}
