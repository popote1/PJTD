
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class GameSetter : MonoBehaviour
{
    [Header("start setting")]
    public int StartHP =100;
    public int StartMoney = 150;
    
    [Header("UI")]
    public TMP_Text Money;
    public  Slider HP;
    public Button StarWaveBP;

    [Header("Grid")] 
    public  Transform GridOrigine;
    public  float CellSize;
    public  int NombreLigne;
    public  int NombreCollone;
    private Grid _buildingGrid;

    [Header("Building")]
    public GameObject Tourelle1;
    public GameObject LightTourelle;
    public GameObject MediumTourelle;
    public GameObject HeavyTourelle;
    public GameObject LightSmashTourel;
    public GameObject MediumSmashToure;
    public GameObject HeavySmashTourel;
    public GameObject Tourelle1Holo;
    public GameObject SmashTourelHolo;
    public GameObject CaseVert;
    public GameObject ObjetVide;
    public List<Vector2> CaseNonConstructible;
    private List<GameObject> _caseVerts = new List<GameObject>();
    private List<Vector2> _freespots;
    private GameObject _objectInHand;
    private int _objetChoise=1;
    private List<GameObject> _tourelles=new List<GameObject>();

    [Header("wavesStisteme")]
    public List<SOwaives> Waves;
    public GameObject Spawner1;
    public GameObject Spawner2;

    [Header("Sound Sisteme")] 
    public AudioClip StartWave;
    public AudioClip EndWave;
    public AudioClip Clip;
    public AudioClip MouseOvert;
    public AudioClip Error;
    private AudioSource _audioSource;
    private int _state;

    private void Awake()
    {
       GameManager.SetUI(Money, HP, StarWaveBP);
       GameManager.SetSpawnSyteme(Waves,Spawner1,Spawner2);
    }

    private void Start()
    {
        GameManager.Money = StartMoney;
        GameManager.HP = StartHP;
        _buildingGrid = new Grid(NombreCollone,NombreLigne,CellSize,GridOrigine.position);
        SetNonConstuctibleCells();
        _state = 0;
        _audioSource = GetComponent<AudioSource>();

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




    public void UIBuildLightTorrelle()
    {
        if (_state == 1)
        {
            _state = 0;
            UIResteConstructionList();
            _state = 1;
        }
        if (GameManager.Money - LightTourelle.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 1;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }
    public void UIBuildMediumTorrelle()
    {
        if (_state == 1)
        {
            _state = 0;
            UIResteConstructionList();
            _state = 1;
        }
        if (GameManager.Money - MediumTourelle.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 2;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }
    public void UIBuildHeavyTorrelle()
    {
        if (_state == 1)
        {
            _state = 0;
            UIResteConstructionList();
            _state = 1;
        }
        if (GameManager.Money -HeavyTourelle.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 3;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }

    public void UIBuildLightSmachTourel()
    {
        if (_state == 1)
        {
            _state = 0;
            UIResteConstructionList();
            _state = 1;
        }
        if (GameManager.Money -LightSmashTourel.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 4;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }
    public void UIBuildMediumSmachTourel()
    {
        if (_state == 1)
        {
            _state = 0;
            UIResteConstructionList();
            _state = 1;
        }
        if (GameManager.Money -MediumSmashToure.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 5;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }
    public void UIBuildHeavySmachTourel()
    {
        
        if (GameManager.Money -HeavySmashTourel.GetComponent<TourelleHolder>().TourelInfo.Cost >= 0)
        {
            _objetChoise = 6;
            UIContructionListe();
        }
        else
        {
            PlayError();
            Debug.Log("Pas assez d'argent");
        }
    }
    
    private void UIContructionListe()
    {
        PlayOnClick();
       List<Vector2>freeCells = _buildingGrid.CheckFreeCells();
       foreach (Vector2 pos in freeCells)
       {
           GameObject obj = Instantiate(CaseVert, _buildingGrid.GetWorldPositionCenter((int) pos.x, (int) pos.y),
               Quaternion.identity);
           
           _caseVerts.Add(obj);

       }

       _state = 1;
       if (_objetChoise < 4)
       {
           _objectInHand = Instantiate(Tourelle1Holo, Vector3.zero, Quaternion.identity);
       }
       else
       {
           _objectInHand = Instantiate(SmashTourelHolo, Vector3.zero, Quaternion.identity);
       }
    }

    public void UIResteConstructionList()
    {
        foreach (GameObject obj in _caseVerts)
        {
            Destroy(obj);
        }
       Destroy(_objectInHand);
    }

    public void UIStartSpawn()
    {PlayStartWave();
        GameManager.StartSpawn();
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
        GameObject nextbuild =LightTourelle;
        switch (_objetChoise)
        {case 1 : nextbuild = LightTourelle; break;
        case 2: nextbuild = MediumTourelle; break;
        case 3 : nextbuild = HeavyTourelle; break;
        case 4: nextbuild = LightSmashTourel; break;
        case 5 : nextbuild = MediumSmashToure; break;
        case 6 : nextbuild = HeavySmashTourel; break;
        }
        GameObject tourelle =Instantiate(nextbuild, _buildingGrid.GetWorldPositionCenter(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13f))), Quaternion.identity);
        _buildingGrid.SetGameObjectOnGrid(tourelle ,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13f)) );
        _tourelles.Add(tourelle);
        GameManager.Money -= (int)tourelle.GetComponent<TourelleHolder>().TourelInfo.Cost;
       // Debug.Log("onput mouse pos = " + Input.mousePosition);
        _state = 0;
        UIResteConstructionList();
    }

    private void PlayOnClick()
    {
        _audioSource.clip = Clip;
        _audioSource.Play();
    }

    public void PlayOnMouseOver(){
        _audioSource.clip = MouseOvert;
        _audioSource.Play();
    }
    private void PlayError(){
        _audioSource.clip = Error;
        _audioSource.Play();
    }
    private void PlayStartWave(){
        _audioSource.clip = StartWave;
        _audioSource.Play();
    }
    



}
