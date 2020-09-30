using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public class TourelleHolder : MonoBehaviour
{
    public LayerMask LayerMask;
    public SOTourel TourelInfo;
    [HideInInspector] public string Name;
    protected float _range;
    protected float _fireRate;
    protected int _damage;
    protected int _specialType;
    protected int _spacialDamage;
    protected GameObject _target;
    //public Collider[] NearColliders => Physics.OverlapSphere(transform.position, _range);
    protected Collider[] _cachedNearColliders = new Collider[100];
    public Collider[] NonAllocNearColliders
    {
        get
        {
            
            Physics.OverlapSphereNonAlloc(transform.position, _range, _cachedNearColliders, LayerMask);
            return _cachedNearColliders;
        }
        
    }

    protected float _shootTimer = 0;

    protected void Start()
    {
        _range = TourelInfo.Range;
        _fireRate = TourelInfo.FireRate;
        _damage = TourelInfo.Damage;
        switch (TourelInfo.SpecialType)
        {case SOTourel._specialType.Leger:
            _specialType = 1;
            break;
        case SOTourel._specialType.normal:
            _specialType = 2;
            break;
        case SOTourel._specialType.Blinder :
            _specialType = 3; 
            break;
        }

        _spacialDamage = TourelInfo.SpecialDamage;
    }

    

   /* protected void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position,_range);
        
    }*/
}
