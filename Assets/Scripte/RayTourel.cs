using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTourel : TourelleHolder
{
    // Start is called before the first frame update
   

    // Update is called once per frame
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

    
}
