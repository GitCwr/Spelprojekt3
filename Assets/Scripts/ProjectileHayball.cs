using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHayball : MonoBehaviour
{

    public GameObject tower;
    public GameObject target;
    
    public float speed = 10f;
    public int damage = 20;

    private float towerX;
    private float targetX;

    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
        towerX = tower.transform.position.x;
        targetX = target.transform.position.x;

        dist = targetX - towerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(tower.transform.position.y, target.transform.position.y, (nextX - towerX) / dist);
        height = 2 * (nextX - towerX) * (nextX - targetX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        

        //if(transform.position == target.transform.position)
        //{        
        //    Destroy(gameObject);
       // }
    }

    


    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0,0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
