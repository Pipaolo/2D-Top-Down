using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{
    
    #region Singleton

    private static SpawnManager _instance;

    public static SpawnManager Instance { get { return _instance; } }

        
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion
    
    private Collider2D _spawnCollider;

    [SerializeField] private GameObject prefab;
    
    [SerializeField]
    private float spawnDelay = 1f;
    
    [SerializeField]
    private bool isEnabled = false;
    


    // Start is called before the first frame update
    void Start()
    {
        
        _spawnCollider = GetComponent<Collider2D>();
        
    }

    public void Reset()
    {
        CancelInvoke(nameof(Spawn));
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            DestroyImmediate(enemy);
        }
    }

    public void StartSpawner()
    {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);

    }

    

    private void Spawn()
    {
        var bounds = _spawnCollider.bounds;
        var offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        var offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        var offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        var enemyTemp = Instantiate(prefab);
        enemyTemp.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
    }


 
}
