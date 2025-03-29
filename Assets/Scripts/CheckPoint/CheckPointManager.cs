using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPointkey = 0;

    public List<CheckPointBase> checkpoints;

    public bool HasCheckpoint()
    {
        return lastCheckPointkey > 0;
    }

    public void saveCheckpoint(int i)
    {
        if(i > lastCheckPointkey)
        {
            lastCheckPointkey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckPoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckPointkey);
        checkpoint.RevavelPlayer();
        return checkpoint.transform.position;
    }
}
