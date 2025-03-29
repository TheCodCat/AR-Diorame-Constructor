using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BlockSpawn : Block
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private AgentTest navMeshAgent;
    [SerializeField] private ParticleSystem randParticleSystem;

    private void OnEnable()
    {
        SpawnController.OnSpawn += StartSpawn;
    }
    private void OnDisable()
    {
        SpawnController.OnSpawn -= StartSpawn;
    }
    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 vector3 = new Vector3(0,Random.rotation.eulerAngles.y,0);
            var human =  Instantiate(navMeshAgent, spawnPoints[i].position, Quaternion.identity);
            human.transform.localEulerAngles = vector3;

            randParticleSystem.transform.position = spawnPoints[i].position;
            randParticleSystem.Play();
            SpawnController.OnSpawn -= StartSpawn;
            yield return null;
        }
    }
}
