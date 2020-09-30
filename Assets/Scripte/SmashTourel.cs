using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SmashTourel : TourelleHolder
{
    public GameObject CentreAxe;
    private List<Collider> _enemiInZone;
    // Start is called before the first frame update
  

    private void Update()
    {
        if (Physics.OverlapSphere(transform.position, _range / 4, LayerMask).Length > 0)
        {
            Debug.Log(" Ya des enemie dans la range !!!!");
            _shootTimer += Time.deltaTime;
            if (_shootTimer >= _fireRate )
            {
                _enemiInZone = Physics.OverlapSphere(transform.position, _range / 4, LayerMask).ToList();
                foreach (Collider enemiCol in _enemiInZone)
                {
                    if (enemiCol.GetComponent<UniteMove>().Type == _specialType)
                    {
                        enemiCol.GetComponent<UniteMove>().HP -= _spacialDamage;
                    }
                    else
                    {
                        enemiCol.GetComponent<UniteMove>().HP -= _damage;
                    }
                }

                _shootTimer = 0;
            }
        }
        else
        {
            if (_shootTimer > 0)
            {
                _shootTimer -= Time.deltaTime;
                if (_shootTimer < 0) _shootTimer = 0;
            }
        }
        CentreAxe.transform.localPosition =new Vector3(0,2*_shootTimer/_fireRate,0);
        Debug.Log("timer = "+_shootTimer+ " valuer intermoper  ="+2*_shootTimer/_fireRate+ " timer Charge = "+_shootTimer + " FireRate = "+_fireRate+ " la range est de "+_range);

    }
    public void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position,_range);
        
    }
}
