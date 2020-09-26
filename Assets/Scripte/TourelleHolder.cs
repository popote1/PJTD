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
    private float _range;
    private float _fireRate;
    private int _damage;
    private int _specialType;
    private int _spacialDamage;
    private GameObject _target;
    //public Collider[] NearColliders => Physics.OverlapSphere(transform.position, _range);
    private Collider[] _cachedNearColliders = new Collider[100];
    public Collider[] NonAllocNearColliders
    {
        get
        {
            
            Physics.OverlapSphereNonAlloc(transform.position, _range, _cachedNearColliders, LayerMask);
            return _cachedNearColliders;
        }
        
    }

    private float _shootTimer;

    private void Start()
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

    private void Update()
    {
        if (!_target)
        {
            float smallerDistance = Mathf.Infinity;

            
            
                foreach (Collider nearCollider in NonAllocNearColliders)
                {
                    if (nearCollider == null) break;
                    float distance = Vector3.Distance(transform.position, nearCollider.transform.position);
                    if (distance < smallerDistance)
                    {
                        smallerDistance = distance;
                        _target = nearCollider.gameObject;
                        for (int i = 0; _cachedNearColliders.Length > i; i++)
                        {
                            _cachedNearColliders[i] = null;
                        }

                    }
                
            }
        }

        if (_target == null) return;
            
            
            transform.forward = _target.transform.position-transform.position;
            //Debug.DrawLine(transform.position,_target.transform.position,Color.green);
            if (Vector3.Magnitude(transform.position - _target.transform.position) > _range)
            {
                _target = null;
            }

            _shootTimer += Time.deltaTime;
            if(_shootTimer>=_fireRate)
            {
                _target.GetComponent<UniteMove>().TakeDamage(_damage,_specialType,_spacialDamage);
                _shootTimer = 0;
                Debug.DrawLine(transform.position,_target.transform.position,Color.red,0.25f);
            }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position,_range);
        
    }
}
