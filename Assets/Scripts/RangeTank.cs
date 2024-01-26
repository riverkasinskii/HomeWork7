using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float distanceToPlayer = 5f;
    private float timer;
    private Transform target;

    protected override void Start()
    {
        base.Start();        
        target = FindObjectOfType<Player>().transform;
    }        

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > distanceToPlayer)
        {
            Move();
        }
        SetAngle(target.position);
        if (timer <= 0)
        {
            Shoot();
            timer = reloadTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
