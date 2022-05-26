using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JustDrag : MonoBehaviour
{
    private Camera _cam;
    private Ray _ray;
    private Transform _selectedObject;
    private Plane _plane;

    public GameObject efect, efect1, efect2;



    public Vector3 firstPos;
    public bool drag = false;

    private float y;
    private float x, z;


    private bool correc;
    private bool ful;



    private void Start()
    {
        _plane = new Plane(Vector3.up, new Vector3(0, 6f, 0));
        _cam = Camera.main;



    }

    private void Update()
    {



        _ray = _cam.ScreenPointToRay(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(_ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Blue") || hitInfo.collider.CompareTag("Green") || hitInfo.collider.CompareTag("Pink") || hitInfo.collider.CompareTag("Red"))
                {
                   
                    _selectedObject = hitInfo.collider.transform;
                    firstPos = hitInfo.collider.transform.position;



                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_selectedObject)
            {
                float distance = 0;
                if (_plane.Raycast(_ray, out distance))
                {
                    _selectedObject.transform.position = _ray.GetPoint(distance);
                    _selectedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                }
            }
        }



        if (Input.GetMouseButtonUp(0))
        {
            if (correc)
            {
                _selectedObject.DOMove(new Vector3(x,y,z),0.2f);
                //_selectedObject.DOMoveY(y, 0.1f);
                _selectedObject = null;


            }
            else if(!correc)
            {

                    _selectedObject.transform.DOMove(firstPos, 1f);
                    _selectedObject = null;      

            }


        }
        y = Controller.lastTorusY;
        x = Object.x;
        z = Object.z;


    

        correc = Controller.correct;
        ful = Controller.full;


        if (Input.GetKeyDown(KeyCode.A))
        {
            efect.SetActive(true);
            efect1.SetActive(true);
            efect2.SetActive(true);
        }

    }
    public void Finish() 
    {
        print("finish");
        efect.SetActive(true);
        efect1.SetActive(true);
        efect2.SetActive(true);
    }



}
