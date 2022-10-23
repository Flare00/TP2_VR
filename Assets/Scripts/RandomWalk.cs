using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public float mRange = 25.0f;
    Vector2 lastPos;
    UnityEngine.AI.NavMeshAgent mAgent;
    Vector2 randomPos;
    void Start()
    {
        mAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        if (mAgent.pathPending || mAgent.remainingDistance > 0.1f)
            return;
        randomPos = Random.insideUnitCircle * mRange;
        if (randomPos == lastPos)
            randomPos = Random.insideUnitCircle * mRange;
        mAgent.destination = new Vector3(randomPos.x, 0, randomPos.y);
    }
}
