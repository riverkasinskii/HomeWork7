using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int damage = 5;
    private Transform target;
    private float timer;
    private float hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }        

    private void Update()
    {
        if (target != null)
        {
            if (timer <= 0)
            {
                Move();
                SetAngle(target.position);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && timer <= 0)
        {
            player.TakeDamage(damage);
            timer = hitCooldown;
        }        
    }
}
