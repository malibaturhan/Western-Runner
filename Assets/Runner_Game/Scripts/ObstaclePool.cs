using UnityEngine;
using UnityEngine.Pool;
public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Obstacle[] obstaclePrefabs;

    public ObjectPool<Obstacle> obstaclePool;
    public ObjectPool<Enemy> enemyPool;

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(
            createFunc: () =>
            {
                Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
                enemy.gameObject.SetActive(false);
                return enemy;
            },
            actionOnGet: (enemy) =>
            {
                enemy.gameObject.SetActive(true);
                enemy.OnSpawn();
            },
            actionOnRelease: (enemy) =>
            {
                enemy.gameObject.SetActive(false);
                enemy.OnDespawn();
            },
            actionOnDestroy: (enemy) =>
            {
                Destroy(enemy);
            },
            collectionCheck: true,
            defaultCapacity: 30,
            maxSize: 50
            );
        obstaclePool = new ObjectPool<Obstacle>(
            createFunc: () =>
            {
                Obstacle obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
                obstacle.gameObject.SetActive(false);
                return obstacle;
            },
            actionOnGet: (obstacle) =>
            {
                obstacle.gameObject.SetActive(true);
                obstacle.OnSpawn();
            },
            actionOnRelease: (obstacle) =>
            {
                obstacle.gameObject.SetActive(false);
                obstacle.OnDespawn();
            },
            actionOnDestroy: (obstacle) =>
            {
                Destroy(obstacle);
            },
            collectionCheck: true,
            defaultCapacity: 30,
            maxSize: 50
            );
    }



}
