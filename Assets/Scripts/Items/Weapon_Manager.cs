using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Manager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    AddWeapon(StartingWeapon);
  }


  [SerializeField] Transform WeaponContainerTransform;
  [SerializeField] WeaponData StartingWeapon;

  public void AddWeapon(WeaponData weaponData)
  {
    GameObject weaponGameObject = Instantiate(weaponData.WeaponPrefabObject, WeaponContainerTransform);
  }
}
