using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class CarControl : MonoBehaviour
{
    public GameObject Polic, Ambulanc, FireTruc, cam;
    public GameObject Winn, Losee, a3, b2, c1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Police() 
    {
        cam.SetActive(true);
        DOTween.Play("Police");
        DOTween.Play("Camera");
        StartCoroutine(Win());
    }
    public void FireTruck() 
    {
        cam.SetActive(true);
        DOTween.Play("FireTruck");
        DOTween.Play("Camera");
        StartCoroutine(Lose());
    }
    public void Ambulance()
    {
        cam.SetActive(true);
        DOTween.Play("Ambulance");
        DOTween.Play("Camera");
        StartCoroutine(Lose());
    }
    private IEnumerator Lose()
    {

        yield return new WaitForSeconds(3f);
        Losee.SetActive(true);
        yield return new WaitForSeconds(1f);
        a3.SetActive(false);
        b2.SetActive(true);
        yield return new WaitForSeconds(1f);
        b2.SetActive(false);
        c1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Losee.SetActive(false);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);


    }
    private IEnumerator Win()
    {
        yield return new WaitForSeconds(3f);

        Winn.SetActive(true);
        
    }

    public void Losing() 
    {
        StartCoroutine(Lose());
    }
}
