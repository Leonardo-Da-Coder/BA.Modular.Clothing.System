using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ModularClothingSystemManager : MonoBehaviour
{
    public GameObject Model;
    
    public UnityEngine.UI.Button TshirtSwapFor;
    public UnityEngine.UI.Button TshirtSwapPre;
    public UnityEngine.UI.Button PantsSwapPre;
    public UnityEngine.UI.Button PantsSwapFor;


    [Serializable]
    public class StringMeshPairPants
    {
        public string name;
        public GameObject Model;
    }
    [Serializable]
    public class StringMeshPairTshirt
    {
        public string name;
        public GameObject Model;
    }

    public List<StringMeshPairPants> PantsModels = new List<StringMeshPairPants>();
    public List<StringMeshPairTshirt> TshirtModels = new List<StringMeshPairTshirt>();
    
    private GameObject actualTshirtModel;
    private GameObject actualPantsModel;
    private int maxLengthTshirt;
    private int maxLengthPants;
    private int countTshirt = 0;
    private int countPants = 0;
    private GameObject tShirt;
    private GameObject pants;
    void Start()
    {
        TshirtSwapFor.onClick.AddListener(ChangeTshirtModelFor);
        TshirtSwapPre.onClick.AddListener(ChangeTshirtModelPre);
        PantsSwapFor.onClick.AddListener(ChangePantsModelFor);
        PantsSwapPre.onClick.AddListener(ChangePantsModelPre);

        actualTshirtModel = Model.transform.GetChild(2).gameObject;
        actualPantsModel = Model.transform.GetChild(3).gameObject;

        maxLengthPants = PantsModels.Count;
        maxLengthTshirt = TshirtModels.Count;

    }

    void ChangeTshirtModelFor()
    {
        Destroy(actualTshirtModel);
        if (countTshirt < maxLengthTshirt)
        {
            actualTshirtModel = Instantiate(TshirtModels[countTshirt].Model, Model.transform);
        }
        else
        {
            countTshirt = 0;
            actualTshirtModel = Instantiate(TshirtModels[countTshirt].Model, Model.transform);
        }
        countTshirt++;
    }

    void ChangeTshirtModelPre()
    {
        Destroy(actualPantsModel);
        if (countPants < maxLengthPants)
        {
            actualPantsModel = Instantiate(PantsModels[countPants].Model, Model.transform);
        }
        else
        {
            countPants = 0;
            actualPantsModel = Instantiate(PantsModels[countPants].Model, Model.transform);
        }
        countPants++;
    }

    void ChangePantsModelFor()
    {
        Destroy(actualPantsModel);
        print(maxLengthPants);
        if (countPants < maxLengthPants)
        {
            actualPantsModel = Instantiate(PantsModels[countPants].Model, Model.transform);
            if (countPants + 1 < maxLengthPants)
            {
                countPants++;
            }
            else
            {
                countPants = 0;
            }
        }
    }

    void ChangePantsModelPre()
    {
        Destroy(actualPantsModel);
        if (countPants > 0)
        {
            actualPantsModel = Instantiate(PantsModels[countPants].Model, Model.transform);
            if (countPants -1 > 0)
            {
                countPants--;
            }
            else
            {
                countPants = maxLengthPants - 1;
            }
        }
       
    }
}
