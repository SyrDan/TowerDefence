using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAfter))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] float travelPersent;
    [SerializeField] private List<WayPoint> path = new List<WayPoint>();
    [SerializeField] private float speed = 1f;

    private EnemyAfter enemy;
    private WaitForEndOfFrame pathWaitTime;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPoint());
    }

    private void Start()
    {
        pathWaitTime = new WaitForEndOfFrame();
        enemy = GetComponent<EnemyAfter>();
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private void FindPath()
    {
        path.Clear();

        var parent = GameObject.FindGameObjectWithTag("FindPath");
        foreach(Transform child in parent.transform)
        {
            var waypoint = child .GetComponent<WayPoint>();
            if (waypoint != null)
                path.Add(waypoint);
        }
    }

    IEnumerator FollowPoint()
    {
        foreach (var wayPoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 finalPos = wayPoint.transform.position;
            float travelPersent = 0f;

            transform.LookAt(finalPos);
            while (travelPersent < 1f)
            {
                travelPersent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, finalPos, travelPersent);
                yield return pathWaitTime;
            }
            
        }

        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
