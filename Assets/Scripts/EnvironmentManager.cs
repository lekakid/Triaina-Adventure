using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnvironmentManager : MonoBehaviour {
    [System.Serializable]
    public struct Rarity {
        [Range(0.1f, 99.9f)] public float Rate;
        public List<EnvironmentElement> ElementList;
    }
    [SerializeField] List<Rarity> RateTable;
    [SerializeField, Range(0.1f, 2f)] float MaxDelay = 0.5f;
    [SerializeField, Range(0.001f, 0.1f)] float MinDelay = 0.05f;

    Dictionary<string, Queue<EnvironmentElement>> PoolDictionary;

    Animator animator;
    float delay;
    float accumulateDelay;

    void Awake() {
        animator = GetComponent<Animator>();

        PoolDictionary = new Dictionary<string, Queue<EnvironmentElement>>();

        delay = Random.Range(MinDelay, MaxDelay);
    }
    
    void Update() {
        accumulateDelay += Time.deltaTime;

        if(accumulateDelay >= delay) {
            accumulateDelay = 0;
            delay = Random.Range(MinDelay, MaxDelay);
            SpawnElement();
        }
    }

    void SpawnElement() {
        EnvironmentElement selctedPrefab = SelectElementPrefab();
        if(selctedPrefab == null) return;

        Queue<EnvironmentElement> pool;
        if(!PoolDictionary.TryGetValue(selctedPrefab.name, out pool)) {
            pool = new Queue<EnvironmentElement>();
            PoolDictionary.Add(selctedPrefab.name, pool);
        }

        EnvironmentElement element;
        if(pool.Count > 0) {
            element = pool.Dequeue();
        }
        else {
            element = Instantiate<EnvironmentElement>(selctedPrefab, transform);
        }
        element.SetRestoreQueue(pool);
        element.Release();
    }

    EnvironmentElement SelectElementPrefab() {
        float max = 0f;
        foreach(Rarity r in RateTable) {
            max += r.Rate;
        }
        if(max == 0f) return null;

        float chance = Random.Range(0f, max);

        List<EnvironmentElement> selectedTable = null;
        for(int i = RateTable.Count - 1; i >= 0; i--) {
            if(chance <= RateTable[i].Rate) {
                selectedTable = RateTable[i].ElementList;
                break;
            }
            else {
                chance -= RateTable[i].Rate;
            }
        }

        return selectedTable[Random.Range(0, selectedTable.Count)];
    }
}
