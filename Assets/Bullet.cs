using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Init(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dis = speed * Time.deltaTime;

        if (dir.magnitude <= dis)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            return;
        }
        transform.Translate(dir.normalized * dis, Space.World);
    }
}
