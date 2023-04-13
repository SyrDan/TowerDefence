using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform TopMesh;
    [SerializeField] private float radius = 15;
    [SerializeField] private ParticleSystem ProjectileParticle;
    private Transform target;
    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update()
    {
        findClosestTarget();
         AimWeapon();
    }

    private void findClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closseTaregt = null;
        float maxDistence = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            var targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(targetDistance < maxDistence))
                    continue;
            closseTaregt = enemy.transform;
            maxDistence = targetDistance;
        }
        target = closseTaregt;
    }

    void AimWeapon()
    {
        var targetDistance = Vector3.Distance(target.position, transform.position);
        TopMesh.LookAt(target);
        Attack(targetDistance <= radius);
    }
    void Attack(bool isActive)
    {
        var emmission = ProjectileParticle.emission;
        emmission.enabled = isActive;
    }
}
