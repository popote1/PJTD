using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
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
    public GameObject CaseVert;
    public GameObject ObjetVide;
    public List<Vector2> CaseNonConstructible;
    private List<GameObject> _caseVerts = new List<GameObject>();
    private List<Vector2> _freespots;

    private void Awake()
    {
        GameManager.money = StartMoney;
        GameManager.HP = StartHP;
    }

    private void Start()
    {
        _buildingGrid = new Grid(NombreCollone,NombreLigne,CellSize,GridOrigine.position);
        ChangeMoney(StartMoney);
        ChangeHP(StartHP);
        SetNonConstuctibleCells();
    }


    public  void ChangeHP(float hp)
    {
        HP.value = hp / 100;
    }

    public  void ChangeMoney(int money)
    {
        Money.text = "" + money;
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
    }

    public void UIResteConstructionList()
    {
        foreach (GameObject obj in _caseVerts)
        {
            Destroy(obj);
        }
       
    }

    private void SetNonConstuctibleCells()
    {
        foreach (Vector2 pos in CaseNonConstructible)
        {
            _buildingGrid.SetGameObjectOnGrid(Instantiate(ObjetVide, Vector3.zero, Quaternion.identity), (int)pos.x,(int) pos. y);
        }
    }
}
