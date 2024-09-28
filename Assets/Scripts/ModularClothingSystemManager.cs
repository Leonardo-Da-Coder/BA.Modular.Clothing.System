using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ModularClothingSystemManager : MonoBehaviour
{
    public GameObject Model;
    
    public UnityEngine.UI.Button TshirtSwapFor;
    public UnityEngine.UI.Button TshirtSwapPre;

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
        TshirtSwapFor.onClick.AddListener(ChangeModelFor);
        TshirtSwapPre.onClick.AddListener(ChangeModelPre);

        actualTshirtModel = Model.transform.GetChild(2).gameObject;
        actualPantsModel = Model.transform.GetChild(3).gameObject;

        maxLengthPants = PantsModels.Count;
        maxLengthTshirt = TshirtModels.Count;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeModelFor()
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

    void ChangeModelPre()
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
}
