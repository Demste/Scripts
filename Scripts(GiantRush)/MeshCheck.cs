using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Material PlayerMat;

    private Material Colormat;



    void Start()
    {

    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==player.gameObject.tag)
        {
            //Coorec();
         
            //foreach (Transform copy in other.transform)
            //{
                
            //    Colormat = copy.GetComponent<SkinnedMeshRenderer>().material;
            //}

            //foreach (Transform child in player.transform)
            //{
            //    //child.GetComponent<SkinnedMeshRenderer>().material = PlayerMat; playerın rengini player mat yap
            //    PlayerMat = child.GetComponent<SkinnedMeshRenderer>().material;
                
            //}
            //if (Colormat=PlayerMat)
            //{
            //    print(true);
            //}
            //else
            //{
            //    print("false");
            //}
        }
        if (other.gameObject.tag != player.gameObject.tag)
        {
            //Wrong();
        }

    }
}
