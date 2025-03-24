using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enimy
{
    public class EnimyWalk : EnemyBase
    {
        [Header("waypoints")]
        public GameObject[] waypoints;
        public float minDistance;
        public float speed;

        private int _index;

        private void Update()
        {
            if (!_isDead)
            {
                if (Vector3.Distance(transform.position, new Vector3(waypoints[_index].transform.position.x, transform.position.y, waypoints[_index].transform.position.z)) < minDistance)
                {
                    _index++;
                    if (_index >= waypoints.Length)
                    {
                        _index = 0;
                    }
                }


                transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[_index].transform.position.x, transform.position.y, waypoints[_index].transform.position.z), Time.deltaTime * speed);
                transform.LookAt(new Vector3(waypoints[_index].transform.position.x, transform.position.y, waypoints[_index].transform.position.z));
            }
        }
    }
}
