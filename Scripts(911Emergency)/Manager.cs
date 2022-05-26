using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
    private GameObject Button1, Button2;
    public GameObject canvas;
    public GameObject[] EmptyText;//0 dispatcher 1 caller;
    public GameObject[] Buttons;
    private List<GameObject> Text = new List<GameObject>();
    public GameObject cameraa;
    public Button Answerr, Ambulance, FireTruck, Police;
    private float y = 1.6f;
    private bool bir=false, iki=false;
    public GameObject carcontrl;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InstanDispatcher("a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            InstanCaller("s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Slideup();
        }
        if (y<-3.4)
        {
            y = -3.4f;
        }


    }
    public void Answer() 
    {
        Answerr.gameObject.SetActive(false);
        cameraa.transform.DOMove(new Vector3(0f,0f,-11f),1.5f);
        cameraa.transform.DORotate(new Vector3(0,0,0),1.5f);
        StartCoroutine(Game());
    }


    public void InstanDispatcher(string a) 
    {
        Vector3 poss = new Vector3(10f, y, -0.25f);
        GameObject clone;
        clone = Instantiate(EmptyText[0], poss, Quaternion.identity);
        clone.GetComponent<TextMeshPro>().text = a;
        y -= 1;
        
        Text.Add(clone);
    }
    public void InstanCaller(string s) 
    {
        Vector3 poss = new Vector3(5.2f, y, -0.25f);
        GameObject clone;
        clone = Instantiate(EmptyText[1], poss, Quaternion.identity);
        clone.GetComponent<TextMeshPro>().text = s;
        y -= 1;
        Text.Add(clone);
    }

    private void Slideup() 
    {
        for (int i = 0; i < Text.Count; i++)
        {
            GameObject clone;
            clone = Text[i];

            clone.transform.DOMoveY(clone.transform.position.y + 1f,1f);
            if (clone.transform.position.y > 2f)
            {
                clone.SetActive(false);
            }
        }
    }

    private void OpenButton(string buton1,string buton2) 
    {
        Vector3 poss = new Vector3(512f, 415, 0f);

        Button1 = Instantiate(Buttons[0], poss, Quaternion.identity);
        Button1.transform.parent = canvas.gameObject.transform;
        Button1.transform.GetChild(0).GetComponent<Text>().text = buton1;
        Vector3 posss = new Vector3(512f, 302, 0f);

        Button2 = Instantiate(Buttons[1], posss, Quaternion.identity);
        Button2.transform.parent = canvas.gameObject.transform;
        Button2.transform.GetChild(0).GetComponent<Text>().text = buton2;

        Button1.GetComponent<Button>().onClick.AddListener(delegate () { Deneme1(buton1); });
        Button2.GetComponent<Button>().onClick.AddListener(delegate () { Deneme2(buton2); });


    }

    private void Deneme1(string dispatcher) 
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        InstanDispatcher(dispatcher);
        bir = true;


    }
    private void Deneme2(string dispatcher)
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        InstanDispatcher(dispatcher);
        iki = true;

    }
    private IEnumerator Game() 
    {
        yield return new WaitForSeconds(1.5f);
        InstanDispatcher("Acil Durum Servisi Buyrun");
        yield return new WaitForSeconds(1f);
        InstanCaller("Birileri evimin içinde");
        yield return new WaitForSeconds(1f);
        OpenButton("Adresiniz nedir","Sakin olun sonsuza kadar durmıcaklar");
        yield return new WaitUntil(()=>Input.GetMouseButtonUp(0));
        if (bir)
        {
            yield return new WaitForSeconds(1f);
            InstanCaller("Karaağaçlı Mahallesi/Manisa");            
            bir = false;
            OpenButton("Hırsızlık olduğuna emin misiniz?", "Oraya kargo yollamıyoruz");
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            if (bir)
            {
                yield return new WaitForSeconds(1f);
                InstanCaller("Evet kesinlikle lütfen yardım yollayın");
                Slideup();
                yield return new WaitForSeconds(2f);
                InstanDispatcher("Hemen yönlendiriyorum");
                yield return new WaitForSeconds(1f);
                Ambulance.gameObject.SetActive(true);
                FireTruck.gameObject.SetActive(true);
                Police.gameObject.SetActive(true);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                Ambulance.gameObject.SetActive(false);
                FireTruck.gameObject.SetActive(false);
                Police.gameObject.SetActive(false);
                bir = false;
            }
            else if (iki)
            {
                yield return new WaitForSeconds(1f);
                InstanCaller("Dalga mı geçiyorsunuz?" + " Acil yardım edin");
                Slideup();
                iki = false;
                OpenButton("Evet", "Hemen birimleri yolluyorum");
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                if (bir)
                {
                    yield return new WaitForSeconds(1f);
                    Slideup();
                    yield return new WaitForSeconds(1f);
                    InstanCaller("İlgili yere sizi şikayet edicem");
                    iki = false;
                    carcontrl.GetComponent<CarControl>().Losing();

                }
                else if (iki)
                {
                    yield return new WaitForSeconds(1f);
                    Slideup();
                    yield return new WaitForSeconds(1f);
                    InstanCaller("Teşekkürler");
                    bir = false;
                    yield return new WaitForSeconds(1f);
                    Ambulance.gameObject.SetActive(true);
                    FireTruck.gameObject.SetActive(true);
                    Police.gameObject.SetActive(true);
                    yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                    Ambulance.gameObject.SetActive(false);
                    FireTruck.gameObject.SetActive(false);
                    Police.gameObject.SetActive(false);
                    iki = false;
                }
            }

        }
        else if (iki)
        {
            yield return new WaitForSeconds(1f);
            InstanCaller("Dalga mı geçiyorsunuz?"+ " Acil yardım edin");
            iki = false;
            OpenButton("Hemen birimleri yönlendiriyorum","Evet");
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            if (bir)
            {
                yield return new WaitForSeconds(1f);
                InstanCaller("Teşekkürler");
                bir = false;
                yield return new WaitForSeconds(1f);
                Ambulance.gameObject.SetActive(true);
                FireTruck.gameObject.SetActive(true);
                Police.gameObject.SetActive(true);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                Ambulance.gameObject.SetActive(false);
                FireTruck.gameObject.SetActive(false);
                Police.gameObject.SetActive(false);
            }
            else if (iki)
            {
                yield return new WaitForSeconds(1f);
                InstanCaller("İlgili yere sizi şikayet edicem");
                iki = false;
                carcontrl.GetComponent<CarControl>().Losing();

            }
        }


    }


}
