using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Growing : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public float GrowingMultiplier;
    public float DowningMultiplier;


    public Material[] mats;

    void Start()
    {
        
    }
    private void Update()
    {
        //if (this.gameObject.tag == "Orange")
        //{
        //    materialcolor = 0f;
        //}else if (this.gameObject.tag=="Green")
        //{
        //    materialcolor = 1f;
        //}
        //else if (this.gameObject.tag=="Yellow")
        //{
        //    materialcolor = 2f;
        //}



    }
    private void OnTriggerEnter(Collider other)
    {

        if (this.gameObject.tag==other.gameObject.tag)
        {
            GrowUp();
            //foreach (Transform copy in other.transform)
            //{
            //    copy.GetComponent<Renderer>().enabled = false;
            //}
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;

        }

            if (other.gameObject.tag != player.gameObject.tag && other.gameObject.transform.childCount > 0)
            {
                GrowDown();
                other.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;

            }




            if (other.gameObject.tag=="ChangeOrange")
        {
            gameObject.tag = "Orange";

            player.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material = mats[0];
        }
        if (other.gameObject.tag == "ChangeGreen")
        {
            gameObject.tag = "Green";

            player.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material = mats[1];

        }
        if (other.gameObject.tag == "ChangeYellow")
        {
            gameObject.tag = "Yellow";

            player.gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material = mats[2];
        }
    }
    public void GrowUp() 
    {
        if (transform.localScale.x<6f)
        {
            transform.DOScale(new Vector3(transform.localScale.x + GrowingMultiplier, transform.localScale.y + GrowingMultiplier, transform.localScale.z + GrowingMultiplier), .1f);
        }
        
    }
    public void GrowDown() 
    {
        if (transform.localScale.x>1f)
        {
            transform.DOScale(new Vector3(transform.localScale.x - DowningMultiplier, transform.localScale.y - DowningMultiplier, transform.localScale.z - DowningMultiplier), .1f);
        }
        else
        {
            Death();
        }
    }

    public void Death() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
