using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_Enemies = new List<GameObject>(3);

    [SerializeField]
    float enemyChance;

    void Start()
    {
        foreach(var enemy in m_Enemies)
        {
            if (enemy == null)
                DebugUtility.HandleErrorIfNullFindObject<GameObject, SpawnPoint>(enemy, this);
        }
        enemyChance = Random.value;

        Spawn();
    }

    void Spawn()
    {
        if (enemyChance > 0f && enemyChance <= 0.5f)
        {
            Instantiate(m_Enemies[0], transform);
            Destroy(this);
        }
        else if (enemyChance > 0.5f && enemyChance <= 0.9f)
        {
            Instantiate(m_Enemies[1], transform);
            Destroy(this);
        }
        else if (enemyChance > 0.9f && enemyChance <= 1f)
        {
            Instantiate(m_Enemies[2], transform);
            Destroy(this);
        }
    }

}
