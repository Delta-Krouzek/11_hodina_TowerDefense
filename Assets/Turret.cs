using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform rotateAround;
    public float rotationSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float fireCountdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Lerp(rotateAround.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotateAround.rotation = Quaternion.Euler(0, rotation.y, 0);

        if (fireCountdown <= 0f)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Init(target);
            }
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearesetEnemy = null;
        foreach(var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearesetEnemy = enemy;
            }
        }

        if (nearesetEnemy != null && shortestDistance <= range)
        {
            target = nearesetEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
