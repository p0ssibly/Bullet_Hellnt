using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Manager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    AddWeapon(WeaponObjectList[0]);
  }

  [SerializeField] List<GameObject> WeaponObjectList;
  [SerializeField] Transform WeaponContainerTransform;

  public void AddWeapon(GameObject weapon)
  {
    ScriptableWeapon weaponData = weapon.GetComponent<ScriptableWeapon>();
    //weapon.transform.localScale = new Vector3(weaponData.Data.Size.x, weaponData.Data.Size.y);
    //weaponData.transform.Translate(weaponData.transform.position.x + 1, weaponData.transform.position.y, weaponData.transform.position.z);
    

    Instantiate(weapon, WeaponContainerTransform.parent);
  }
}
