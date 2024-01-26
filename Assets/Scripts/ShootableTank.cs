using UnityEngine;

public abstract class ShootableTank : Tank
{
    [Header("Стрельба")]
    [Space(10)]
    [SerializeField] private string projectileTag;
    [SerializeField] private Transform shootPoint;
    [SerializeField] protected float reloadTime = 0.5f;
    private ObjectPooler objectPooler;

    protected override void Start()
    {
        base.Start();
        objectPooler = ObjectPooler.Instance;
    }

    protected void Shoot()
    {
        objectPooler.SpawnFromPool(projectileTag, shootPoint.position, transform.rotation);
    }
}
