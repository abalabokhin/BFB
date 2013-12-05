using UnityEngine;
using System.Collections;
using System;
using BFB.Models;
using BFB.Cache;
using System.Linq;

public class WeaponWrapper : MonoBehaviour
{
    #region Fields

    public GameObject weaponObject;
    public GameObject parentGameObject;
    private Weapon weapon;
    private LineRenderer laserLine;
    private bool useAlternativeControls = true;
    public bool isPlayer = false;
    public AudioClip laserSound;
    public string[] targetTags = new string[] { Tags.asteroid, Tags.enemyShip };

    #endregion

    #region Methods

    // Use this for initialization
    void Start()
    {
        weapon = new Weapon(weaponObject);

        laserLine = GetComponent<LineRenderer>(); ;
        laserLine.SetVertexCount(2);
        laserLine.SetWidth(0.05f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        laserLine.enabled = false;
        if (isPlayer)
        {
            HandlePlayerShoot();
        }
    }

    private void HandlePlayerShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(laserSound);
        }
        if (Input.GetMouseButton(0))
        {
            FireForward(true);
        }
    }

    public void FireForward(bool fromPlayer)
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, weaponObject.transform.position);
        if (fromPlayer == true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (useAlternativeControls)
            {
                ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            }
            laserLine.SetPosition(1, parentGameObject.camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10000)));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (targetTags.FirstOrDefault(oItem => oItem == hitInfo.collider.tag) != null)
                {
                    hitInfo.collider.gameObject.SendMessage("dealDamage", 10, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tags.player);
            if (player != null)
            {
                Ray ray = new Ray(parentGameObject.transform.position, player.transform.position);
                laserLine.SetPosition(1, player.transform.position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (targetTags.FirstOrDefault(oItem => oItem == hitInfo.collider.tag) != null)
                    {
                        hitInfo.collider.gameObject.SendMessage("dealDamage", 1, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }

    #endregion
}
