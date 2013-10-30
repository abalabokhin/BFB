﻿using UnityEngine;
using System.Collections;
using System;
using BFB.Models;
using BFB.Cache;

public class WeaponWrapper : MonoBehaviour
{
    #region Fields

    public string typeId;
    public GameObject weaponObject;
    public GameObject parentGameObject;
    private Weapon weapon;
    private LineRenderer laserLine;
    private bool useAlternativeControls = false;

    #endregion

    #region Methods

    // Use this for initialization
    void Start()
    {
        weapon = new Weapon(new Guid(typeId), weaponObject);

        laserLine = GetComponent<LineRenderer>(); ;
        laserLine.SetVertexCount(2);
        laserLine.SetWidth(0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            laserLine.enabled = true;
            //rightLaser.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            laserLine.SetPosition(0, weaponObject.transform.position);
            //rightLaser.SetPosition(0, rightWeapon.transform.position);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (useAlternativeControls)
            {
                ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            }
            laserLine.SetPosition(1, parentGameObject.camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1000)));
            //rightLaser.SetPosition(1, ray.direction * 500);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("clicked on " + hitInfo.collider.tag);
                if (hitInfo.collider.tag == Tags.asteroid)
                {
                    hitInfo.collider.gameObject.SendMessage("DestroyObject", gameObject, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            laserLine.enabled = false;
            //rightLaser.enabled = false;
        }
    }

    #endregion
}
