using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ModularClothingSystemManager : MonoBehaviour
{
    public GameObject Model;
    private GameObject oldModel;
    private int counter = 5;
    public UnityEngine.UI.Button TshirtSwapFor;
    public UnityEngine.UI.Button TshirtSwapPre;
    void Start()
    {
        TshirtSwapFor.onClick.AddListener(ChangeModelFor);
        TshirtSwapPre.onClick.AddListener(ChangeModelPre);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeModelFor()
    {
        oldModel = Model;
        Destroy(Model);
        if (counter == 5)
            counter = 0;
        else
        {
            counter++;
        }
        Model = GameObject.CreatePrimitive((PrimitiveType)counter);
        Model.transform.position = oldModel.transform.position;
    }

    void ChangeModelPre()
    {
        oldModel = Model;
        Destroy(Model);
        if (counter == 0)
            counter = 5;
        else
        {
            counter--;
        }

        Model = GameObject.CreatePrimitive((PrimitiveType)counter);
        Model.transform.position = oldModel.transform.position;
    }
}
