using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [Header("Общие характеристики")]
    [Space(10)]
    [SerializeField] private int maxHealth = 30;

    [Range(0, 5)]
    [SerializeField] protected float movementSpeed = 3f;
    [SerializeField] protected float angleOffset = 90f;

    [Tooltip("Скорость поворота")]
    [SerializeField] protected float rotationSpeed = 7f;
    [SerializeField] private int points = 0;

    protected UI ui;
    protected new Rigidbody2D rigidbody2D;
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rigidbody2D = GetComponent<Rigidbody2D>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Stats.Score += points;
            ui.UpdateScoreAndLevel();
            Destroy(gameObject);
        }
        print(currentHealth);
    }

    protected virtual void Move()
    {
        transform.Translate(movementSpeed * Time.deltaTime * Vector2.down);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0, angleZ + angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * rotationSpeed);
    }
}
