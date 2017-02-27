﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour {

    public int minDamage = 25;
    public int maxDamage = 50;
    public float weaponRange = 3.5f;
    private TreeHealth treeHealth;
    private AdvancedEnemyAI advancedAI;

    public Camera FPSCamera;
    private void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(ray, out hitInfo, weaponRange))
            {

                switch (hitInfo.collider.tag)
                {
                    case "Tree":
                        treeHealth = hitInfo.collider.GetComponentInParent<TreeHealth>();
                        AttackTree();
                        break;
                    case "Enemy":
                        advancedAI = hitInfo.collider.GetComponent<AdvancedEnemyAI>();
                        AttackEnemy();
                        break;

                    default:
                        break;



                }
            }
        }
    }

    private void AttackTree()
    {
        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.health -= damage;
    }
    private void AttackEnemy()
    {
        int damage = Random.Range(minDamage, maxDamage);
        advancedAI.TakeDamage(damage);
    }
}
