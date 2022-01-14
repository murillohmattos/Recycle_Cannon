using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Cannon : MonoBehaviour, PlayerControls.ICannonActions
{
    private static Cannon instance;
    public static Cannon MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Cannon>();
            }
            return instance;
        }
    }

    private PlayerControls cannonInput;
        
    public Transform aim; //posição da mira

    public Transform bulletOrigin;
    public GameObject bullet;
    public int bulletDamage = 1;
    public float bulletSpeed = 10f;
    public int[] ammo;
    public TrashType ammoType;

    public TMP_Text[] materialListText;
    

    private void OnEnable()
    {
        cannonInput.Enable();
    }

    private void OnDisable()
    {
        cannonInput.Disable();
    }

    void Awake()
    {
        cannonInput = new PlayerControls();
        cannonInput.Cannon.SetCallbacks(this);
    }

    private void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            materialListText[i].text = ammo[i].ToString();
        }        
    }

    void Update()
    {
        Vector3 point = aim.position;
        transform.LookAt(point);   
    }

    void Shoot()
    {
        GameObject instanceShoot = Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

        instanceShoot.GetComponent<Bullet>().bulletType = ammoType;

        Rigidbody rbShoot = instanceShoot.GetComponent<Rigidbody>();

        rbShoot.velocity = instanceShoot.transform.forward * bulletSpeed;
        Destroy(instanceShoot, 2f);
    }    

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (ammo[(int)ammoType] >= 1)
            {
                Shoot();
                ammo[(int)ammoType] -= 1;

                materialListText[(int)ammoType].text = ammo[(int)ammoType].ToString();
            }            
        }
    }

    //ammo[0] = Plastic
    //ammo[1] = Metal
    //ammo[2] = Organic

    public void SelectAmmo(int whichAmmo)
    {
        switch (whichAmmo)
        {
            case 0:
                ammoType = TrashType.Plastic;
                break;
            case 1:
                ammoType = TrashType.Metal;
                break;
            case 2:
                ammoType = TrashType.Organic;
                break;
        } 
    }

    public void GainAmmo(TrashType trashType, int amount = 1) 
    {
        //switch (trashType)
        //{
        //    case TrashType.Plastic:
        //        ammo[0] += amount;
        //        break;
        //    case TrashType.Metal:
        //        ammo[1] += amount;
        //        break;
        //    case TrashType.Organic:
        //        ammo[2] += amount;
        //        break;
        //}

        ammo[(int)trashType] += amount;

        materialListText[(int)trashType].text = ammo[(int)trashType].ToString();
    }
    
}