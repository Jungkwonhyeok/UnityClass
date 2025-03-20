using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int danage = 5;
    private float attackRange = 10f;
    public LayerMask enemyLayer;
    public Camera cam;
    private Ray ray;
    RaycastHit hit;

    private float IastAttack = 0;
    private float attackCoolTime = 1f;

    private void AttackSystem()
    {
        if (Time.time - IastAttack >= attackCoolTime)
        {
            Hp enemyHp = hit.collider.GetComponent<Hp>();
            Debug.Log("Attack Enemy");
            enemyHp.Damage(danage);
        }
        IastAttack = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    AttackSystem();
                }
            }
        }
    }
}
