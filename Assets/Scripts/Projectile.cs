using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string myTag = string.Empty;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tank tank = collision.gameObject.GetComponent<Tank>();
        if (tank != null && !collision.gameObject.CompareTag(myTag))
        {
            tank.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
