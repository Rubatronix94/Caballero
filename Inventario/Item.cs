using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string descripcion;
    public Sprite icon;
    //public GameObject objeto; ¿??

    [HideInInspector]
    public bool pickedUp;

  //  [HideInInspector]
    public bool equipped;

  //  [HideInInspector]
    public GameObject weaponManager;
  //  [HideInInspector]
    public GameObject weapon;

    public bool playersWeapon;

    private void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
      // weaponManger = GameObject.FindWithTag("PistolaSlot");??
       
        if (!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;

            for (int i = 0; i < allWeapons; i++)
            {
                //DNI DEL OBJETO
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (equipped)
        { // EQUIPAR ARMA
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipped = false;
            }
            if (equipped==false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void UsarItem()
    {
        if (type=="Weapon")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }

       /* switch (type)
        {
            case "Consumible":
                Debug.Log("Consumiendo " + name);
                break;
            case "Arma":
                Debug.Log("Equipando " + name);
                break;
            case "Municion":
                Debug.Log("Recargando " + name);
                break;
            case "Llave":
                Debug.Log("Usando " + name);
                break;
            default:
                break;
        } */
    }   
}
