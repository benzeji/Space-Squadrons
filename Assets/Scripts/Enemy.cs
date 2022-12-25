using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int scoreEnemy;
    [SerializeField] private int hitPoints;

    private ScoreBoard _scoreBoard;
    private GameObject _parentGameObject;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        GravityFalse();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        var vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = _parentGameObject.transform;
        hitPoints--;

    }

    private void KillEnemy()
    {
        _scoreBoard.IncreaseScore(scoreEnemy);
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = _parentGameObject.transform;
        Destroy(gameObject);
    }

    private void GravityFalse()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
