using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private float timer;
    [SerializeField] private List<Gun> guns;

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ui.UpdateHp(currentHealth);
        if (currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected override void Move()
    {
        transform.Translate(Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime * Vector2.down);        
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (timer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                timer = reloadTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
