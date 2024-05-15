using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject bulletPF;
    [SerializeField] private uint mag;
    [SerializeField] private uint rpm;
    [SerializeField] private float reloadTime;

    private uint currentMag;
    private float cd;
    private float timer;
    private bool isReloading;
    private Queue<BulletBehaviour> bulletQ = new();

    private void Start()
    {
        cd = Delta(rpm);
        timer = cd;
        ResetMag();
        PreparePool(bulletQ, bulletPF, spawnPos, mag);
    }

    private void Update()
    {
        timer += Time.deltaTime;
 
    }

    private IEnumerator WaitToReload(float time)
    {
        isReloading = true;
        yield return new WaitForSeconds(time);
        ResetMag();
        isReloading = false;
    }
    public void Shoot()
    {
        if (CanShoot())
        {
            BulletBehaviour bb = bulletQ.Dequeue();
            bb.Shoot(spawnPos, 100f);
            bulletQ.Enqueue(bb);
            timer = 0;
            currentMag--;
        }
    }
    public void Reload()
    {
        if (!isReloading) StartCoroutine(WaitToReload(reloadTime));

    
    }

    private static void PreparePool(Queue<BulletBehaviour> q, GameObject prefab, Transform pos, uint amount)
    {
        q.Clear();
        for (int i = 0; i < amount; i++)
        {
            BulletBehaviour bb = Instantiate(prefab, pos.position, pos.rotation).GetComponent<BulletBehaviour>();
            q.Enqueue(bb);
        }
    }
    private void ResetMag() => currentMag = mag;
    private static float Delta(uint value) => 60f / value;
    private bool CanShoot() => InputHandler.IsShooting && timer >= cd && currentMag > 0 && isReloading;
}