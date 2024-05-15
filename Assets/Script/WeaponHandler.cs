using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
     [SerializeField] private Weapon[] weapons;
     private int currentIndex;

    private void Start()
    {
        DeactivateWeapons();
        weapons[0].gameObject.SetActive(true);
    }

    private void Update()
    {
            UpdateIndex();

            if (InputHandler.IsShooting)
            {
                weapons[currentIndex].Shoot();
            }
            if (InputHandler.HasReloaded)
            {
                weapons[currentIndex].Reload();
            }
            Debug.Log(InputHandler.InputScroll);
    }

        private int  WrapIndex(int index)
        {
            int wrappedindex = currentIndex % weapons.Length;

            currentIndex = wrappedindex < 0 ? wrappedindex += weapons.Length : weapons.Length;

            return currentIndex;
        }

        private void UpdateIndex()
        {
            weapons[currentIndex].gameObject.SetActive(false);
            currentIndex += InputHandler.InputScroll;
            currentIndex = WrapIndex(currentIndex);
            weapons[currentIndex].gameObject.SetActive(true);

        }
        private void DeactivateWeapons()
        {
            foreach (Weapon weapon in weapons) weapon.gameObject.SetActive(false);
        }
}

