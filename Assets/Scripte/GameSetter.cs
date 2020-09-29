using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GameSetter : MonoBehaviour
{
    public TMP_Text Money;
    public  Slider HP;
    [Header("start setting")]
    public int StartHP =100;
    public int StartMoney = 150;
    
    [Header("Grid")] 
    public  Transform GridOrigine;
    public  float CellSize;
    public  int NombreLigne;
    public  int NombreCollone;
    private Grid _buildingGrid;

    [Header("Building")]
    public GameObject Tourelle1;
    public GameObject Tourelle1Holo;
    public GameObject CaseVert;
    public GameObject ObjetVide;
    public List<Vector2> CaseNonConstructible;
    private List<GameObject> _caseVerts = new List<GameObject>();
    private List<Vector2> _freespots;
    private GameObject _objectInHand;
    private List<GameObject> _tourelles=new List<GameObject>();

    private int _state;

    private void Awake()
    {
       GameManager.SetUI(Money, HP);
    }

    private void Start()
    {
        GameManager.Money = StartMoney;
        GameManager.HP = StartHP;
        _buildingGrid = new Grid(NombreCollone,NombreLigne,CellSize,GridOrigine.position);
        SetNonConstuctibleCells();
        _state = 0;
    }

    private void Update()
    {
        if (_state == 1)
        {
            if (Input.GetButton("Fire1"))
            {
                if (_buildingGrid.CheckIfCellIsFree(
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13))))
                {
                    SetBuild();
                }
                else
                {
                    Debug.Log(" La case est inconstructible");
                }
            }

            _objectInHand.transform.position = Vector3.Lerp(_objectInHand.transform.position,
                _buildingGrid.GetWorldPositionCenter(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13))),
                0.5f);
            
        }
    }


    

    public void UIContructionListe()
    {
       List<Vector2>freeCells = _buildingGrid.CheckFreeCells();
       foreach (Vector2 pos in freeCells)
       {
           GameObject obj = Instantiate(CaseVert, _buildingGrid.GetWorldPositionCenter((int) pos.x, (int) pos.y),
               Quaternion.identity);
           
           _caseVerts.Add(obj);

       }

       _state = 1;
       _objectInHand = Instantiate(Tourelle1Holo, Vector3.zero, Quaternion.identity);
    }

    public void UIResteConstructionList()
    {
        foreach (GameObject obj in _caseVerts)
        {
            Destroy(obj);
        }
       Destroy(_objectInHand);
    }

    private void SetNonConstuctibleCells()
    {
        foreach (Vector2 pos in CaseNonConstructible)
        {
            _buildingGrid.SetGameObjectOnGrid(Instantiate(ObjetVide, Vector3.zero, Quaternion.identity,GridOrigine), (int)pos.x,(int) pos. y);
        }
    }

    private void SetBuild()
    {
        GameObject tourelle =Instantiate(Tourelle1, _buildingGrid.GetWorldPositionCenter(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13f))), Quaternion.identity);
        _buildingGrid.SetGameObjectOnGrid(tourelle ,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13f)) );
        _tourelles.Add(tourelle);
       // Debug.Log("onput mouse pos = " + Input.mousePosition);
        _state = 0;
        UIResteConstructionList();
    }

   
}
